using System;
using System.Collections.Generic;

namespace Messanger.Domain.UserModel
{
    public class User : IUser
    {
        private Guid _id;
        public Guid Id
        {
            get { return this._id; }
        }

        private string _login;
        public string Login
        {
            get { return this._login; }
        }

        private string _telephoneNumber;
        public string TelephoneNumber
        {
            get { return this._telephoneNumber; }
        }

        private IEnumerable<Guid> _chatIdCollection;
        public IEnumerable<Guid> ChatIdCollection
        {
            get { return new List<Guid>(this._chatIdCollection); }
        }

        public User(string login, string telephoneNumber)
        {
            this._id = new Guid();
            this._login = login;
            this._telephoneNumber = telephoneNumber;
        }
    }
}