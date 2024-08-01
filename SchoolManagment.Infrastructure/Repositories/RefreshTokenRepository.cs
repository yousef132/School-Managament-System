using Microsoft.EntityFrameworkCore;
using SchoolManagment.Data.Entities.Identity;
using SchoolManagment.Infrastructure.Abstracts;
using SchoolManagment.Infrastructure.Data;
using SchoolManagment.Infrastructure.InfrastructureBases;

namespace SchoolManagment.Infrastructure.Repositories
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {

        #region Fields
        private readonly DbSet<UserRefreshToken> userRefreshTokens;

        #endregion

        #region Constructor
        public RefreshTokenRepository(ApplicationDbContext context)
            : base(context)
        {
            userRefreshTokens = context.Set<UserRefreshToken>();
        }
        #endregion


        #region Functions

        #endregion
    }
}
