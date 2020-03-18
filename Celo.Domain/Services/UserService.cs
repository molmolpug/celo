using Celo.Common.Extensions;
using Celo.Data.Persistance.Interfaces;
using Celo.Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Celo.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddUser(ViewModels.User user)
        {
            if (!VerifyUser(user))
                return;

            Data.Models.ProfileImage profileImageS = null;
            if (!string.IsNullOrEmpty(user.ProfileImageS))
                profileImageS = AddProfileImage(user.ProfileImageS);

            Data.Models.ProfileImage profileImageL = null;
            if (!string.IsNullOrEmpty(user.ProfileImageL))
                profileImageL = AddProfileImage(user.ProfileImageL);

            _unitOfWork.UserRepository.Add(new Data.Models.User
            {
                Id = Guid.NewGuid(),
                Email = user.Email,
                Title = user.Title,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DoB = user.DoB,
                PhoneNumber = user.PhoneNumber,
                ProfileImageSId = profileImageS?.Id,
                ProfileImageLId = profileImageL?.Id,
            });
            _unitOfWork.SaveChanges();
        }

        public void DeleteUser(Guid id)
        {
            var user = _unitOfWork.UserRepository.Get(id);
            if (user == null) return;

            _unitOfWork.UserRepository.Remove(user);
            _unitOfWork.SaveChanges();
        }

        public ViewModels.User GetUser(Guid id)
        {
            //var user = _unitOfWork.UserRepository.Get(id);
            var user = _unitOfWork.UserRepository.GetAll()
                .Include(x => x.ProfileImageL)
                .SingleOrDefault(x => x.Id == id);

            if (user == null) return null;

            return new ViewModels.User
            { 
                Id = user.Id,
                Email = user.Email,
                Title = user.Title,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DoB = user.DoB,
                PhoneNumber = user.PhoneNumber,
                ProfileImageL = user.ProfileImageL != null ? Convert.ToBase64String(user.ProfileImageL.Image) : null
            };
        }

        public IEnumerable<ViewModels.User> GetUsers(string term, int limit)
        {
            return _unitOfWork.UserRepository.GetUsers(term, limit)
                .Include(x => x.ProfileImageS)
                .Select(user => new ViewModels.User
                {
                    Id = user.Id,
                    Email = user.Email,
                    Title = user.Title,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DoB = user.DoB,
                    PhoneNumber = user.PhoneNumber,
                    ProfileImageS = user.ProfileImageS != null ? Convert.ToBase64String(user.ProfileImageS.Image) : null
                });
        }

        public void UpdateUser(Guid id, ViewModels.User user)
        {
            if (!VerifyUser(user))
                return;

            var existing = _unitOfWork.UserRepository.Get(id);
            if (existing == null) return;

            existing.Email = user.Email;
            existing.FirstName = user.FirstName;
            existing.LastName = user.LastName;
            existing.DoB = user.DoB;
            existing.PhoneNumber = user.PhoneNumber;

            if (string.IsNullOrEmpty(user.ProfileImageS))
            {
                if(existing.ProfileImageS != null)
                    _unitOfWork.Repository<Data.Models.ProfileImage, Guid>().Remove(existing.ProfileImageS);
                existing.ProfileImageSId = null;
            }
            else
            {
                var profileImage = UpsertProfileImage(user.ProfileImageS, existing.ProfileImageS);
                existing.ProfileImageSId = profileImage.Id;
            }

            if (string.IsNullOrEmpty(user.ProfileImageL))
            {
                if (existing.ProfileImageL != null)
                    _unitOfWork.Repository<Data.Models.ProfileImage, Guid>().Remove(existing.ProfileImageL);
                existing.ProfileImageLId = null;
            }
            else
            {
                var profileImage = UpsertProfileImage(user.ProfileImageL, existing.ProfileImageL);
                existing.ProfileImageLId = profileImage.Id;
            }
            _unitOfWork.UserRepository.Update(existing);
            _unitOfWork.SaveChanges();
        }

        private Data.Models.ProfileImage UpsertProfileImage(string image, Data.Models.ProfileImage profileImage)
        {
            if (profileImage == null)
            {
                profileImage = AddProfileImage(image);
            }
            else
            {
                profileImage.Image = Convert.FromBase64String(image);
                _unitOfWork.Repository<Data.Models.ProfileImage, Guid>().Update(profileImage);
            }

            return profileImage;
        }

        private Data.Models.ProfileImage AddProfileImage(string image)
        {
            var profileImage = new Data.Models.ProfileImage 
            {
                Id = Guid.NewGuid(),
                Image = Convert.FromBase64String(image)
            };
            _unitOfWork.Repository<Data.Models.ProfileImage, Guid>().Add(profileImage);
            return profileImage;
        }

        private bool VerifyUser(User user) => user.Email.IsEmail();
    }

    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public readonly double Distance => Math.Sqrt(X * X + Y * Y);

        public readonly override string ToString() =>
            $"({X}, {Y}) is {Distance} from the origin";
    }

}
