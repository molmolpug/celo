using System;
using System.Linq;
using Celo.Data.Models;
using Celo.Domain.Services;
using Celo.Domain.Tests.Base;
using NSubstitute;
using Xunit;

namespace Celo.Domain.Tests.Services
{
    public class UserServiceTests : CeloTestBase
    {
        internal UserService _userService;
        public UserServiceTests()
        {
            _userService = new UserService(_unitOfWork);
        }

        [Fact]
        public void AddUser_User_AddedCorrectly()
        {
            // arrange
            var user = new ViewModels.User
            {
                FirstName = "John",
                LastName = "Key",
                Email = "aaa@test.com",
                DoB = Convert.ToDateTime("1979/10/06")
            };

            // act
            _userService.AddUser(user);

            // assert
            _unitOfWork.UserRepository.Received(1).Add(Arg.Is<User>(x =>
                x.FirstName == "John" &&
                x.LastName == "Key" &&
                x.Email == "aaa@test.com"
                ));
        }

        [Fact]
        public void AddUser_UserWithProfileImages_AddedCorrectly()
        {
            // arrange
            var user = new ViewModels.User
            {
                FirstName = "John",
                LastName = "Key",
                Email = "aaa@test.com",
                DoB = Convert.ToDateTime("1979/10/06"),
                ProfileImageL = "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"
            };

            // act
            _userService.AddUser(user);

            // assert
            _unitOfWork.Repository<ProfileImage, Guid>().Received(1).Add(Arg.Is<ProfileImage>(x => x.Image != null));

            _unitOfWork.UserRepository.Received(1).Add(Arg.Is<User>(x =>
                x.FirstName == "John" &&
                x.LastName == "Key" &&
                x.Email == "aaa@test.com" &&
                x.ProfileImageLId != null
                ));
            _unitOfWork.Received(1).SaveChanges();
        }

        [Fact]
        public void AddUser_CUserWithIncorrectEmail_NotToBeAdded()
        {
            // arrange
            var user = new ViewModels.User
            {
                FirstName = "John",
                LastName = "Key",
                Email = "aaaaatest.com",
                DoB = Convert.ToDateTime("1979/10/06")
            };

            // act
            _userService.AddUser(user);

            // assert
            _unitOfWork.UserRepository.Received(0).Add(Arg.Any<User>());
            _unitOfWork.Received(0).SaveChanges();

        }

        [Theory]
        [InlineData("05e49f84-ba33-47d4-afb7-7a4f7a58a599", 1)]
        [InlineData("00000000-0000-0000-0000-000000000000", 0)]
        [InlineData("05e49f84-ba33-47d4-afb7-7a4f7a58aabc", 0)]
        public void DeleteUser_DeleteCorrectly_WhenIdExist(string requestId, int callCount)
        {
            // arrange
            var existingUserId = new Guid("05e49f84-ba33-47d4-afb7-7a4f7a58a599");
            var user = new User
            {
                Id = existingUserId,
                FirstName = "John",
                LastName = "Key",
                Email = "aaa@test.com",
                DoB = Convert.ToDateTime("1979/10/06")
            };
            _unitOfWork.UserRepository.GetAll().Returns(new[] { user }.AsQueryable());


            // act
            _userService.DeleteUser(new Guid(requestId));

            // assert
            _unitOfWork.UserRepository.Received(callCount).Remove(user);
            _unitOfWork.Received(callCount).SaveChanges();
        }

        [Fact]
        public void GetUser_GetCorrectly()
        {
            // arrange
            var existingUserId = new Guid("05e49f84-ba33-47d4-afb7-7a4f7a58a599");
            var user = new User
            {
                Id = existingUserId,
                FirstName = "John",
                LastName = "Key",
                Email = "aaa@test.com",
                DoB = Convert.ToDateTime("1979/10/06")
            };
            _unitOfWork.UserRepository.GetAll().Returns(new []{ user }.AsQueryable());

            // act
            var result = _userService.GetUser(existingUserId);

            // assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetUsers_GetCorrectly()
        {
            // arrange
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            var user1 = new User
            {
                Id = userId1,
                FirstName = "John",
                LastName = "Key",
                Email = "aaa@test.com",
                DoB = Convert.ToDateTime("1979/10/06")
            };
            var user2 = new User
            {
                Id = userId2,
                FirstName = "Test",
                LastName = "User",
                Email = "test.user@test.com",
                DoB = Convert.ToDateTime("2000/10/06"),
                ProfileImageS = new ProfileImage { Id = Guid.NewGuid(), Image = Convert.FromBase64String("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") }
            };
            _unitOfWork.UserRepository.GetUsers(Arg.Any<string>(), Arg.Is<int>(20)).Returns(new[] { user1, user2 }.AsQueryable());

            // act
            var result = _userService.GetUsers(null, 20);

            // assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void UpdateUser_UpdateCorrectly()
        {
            // arrange
            var userId = Guid.NewGuid();
            var existing = new User
            {
                Id = userId,
                FirstName = "John",
                LastName = "Key",
                Email = "aaa@test.com",
                DoB = Convert.ToDateTime("1979/10/06")
            };

            var updateUser = new ViewModels.User
            {
                Id = userId,
                FirstName = "Ken",
                LastName = "Kato",
                Email = "bbb@test.com",
                DoB = Convert.ToDateTime("2000/10/06"),
                PhoneNumber = "0123456789"
            };

            _unitOfWork.UserRepository.Get(userId).Returns(existing);

            // act
            _userService.UpdateUser(userId, updateUser);

            // assert
            _unitOfWork.UserRepository.Received(1).Update(Arg.Is<User>(x => 
                x.Id == userId &&
                x.FirstName == "Ken" &&
                x.LastName == "Kato" &&
                x.Email == "bbb@test.com" &&
                x.DoB == Convert.ToDateTime("2000/10/06") &&
                x.PhoneNumber == "0123456789"
            ));
            _unitOfWork.Received(1).SaveChanges();
        }
    }
}
