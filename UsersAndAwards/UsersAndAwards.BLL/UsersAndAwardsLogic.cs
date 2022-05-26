using System;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.Entities;

namespace UsersAndAwards.BLL
{
    public class UsersAndAwardsLogic :  IUsersAndAwardsLogic
    {
        private readonly IUserAndAwardsDAO _dao;

        public UsersAndAwardsLogic(IUserAndAwardsDAO dao) =>
            _dao = dao;


        #region Commands
        #endregion

        #region Queries
        #endregion

    }
}
