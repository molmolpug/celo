using Celo.Data.Interfaces;
using Celo.Data.Persistance.Interfaces;
using NSubstitute;
using System;

namespace Celo.Domain.Tests.Base
{
    public class CeloTestBase
    {
        internal IUnitOfWork _unitOfWork;
        internal IUserRepository _userRepository;
        internal IRepository<Data.Models.ProfileImage, Guid> _profileImageRepository;

        public CeloTestBase()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _userRepository = Substitute.For<IUserRepository>();
            _profileImageRepository = Substitute.For<IRepository<Data.Models.ProfileImage, Guid>>();

            _unitOfWork.UserRepository.Returns(_userRepository);
            _unitOfWork.Repository<Data.Models.ProfileImage, Guid>().Returns(_profileImageRepository);
        }
    }
}
