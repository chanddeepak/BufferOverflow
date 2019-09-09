using Nagarro.BufferOverflow.EntityDataModel;
using Nagarro.BufferOverflow.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BufferOverflow.Data
{
    public class UserDAC : DACBase, IUserDAC
    {
        public UserDAC()
            : base(DACType.UserDAC)
        {}

        /// <summary>
        /// Method to get user profile
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public IUserDTO GetProfile(IUserDTO userDTO)
        {
            using(var context = new BufferOverflowDBEntities())
            {
                var user = context.User.SingleOrDefault(u => u.Id == userDTO.Id);
                if(user != null)
                {
                    EntityConverter.FillDTOFromEntity(user, userDTO);
                }

                return (userDTO.Id != 0) ? userDTO : null;
            }
        }

        /// <summary>
        /// Method to register user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public IUserDTO Register(IUserDTO userDTO)
        {
            using (var context = new BufferOverflowDBEntities())
            {
                User user = new User();
                EntityConverter.FillEntityFromDTO(userDTO, user);
                string Password = user.Password;

                string Encrypted = EncryptionAndDecryption.Encrypt(Password, EncryptionAndDecryption.EncryptionKey);
                user.Password = Encrypted;

                bool isExist = context.User.Any(u => u.Email == user.Email);
                if (!isExist)
                {
                    user = context.User.Add(user);
                    context.SaveChanges();
                    EntityConverter.FillDTOFromEntity(user, userDTO);

                }

                return (userDTO.Id != 0) ? userDTO : null;
            }
        }

        /// <summary>
        /// Method to Login user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public IUserDTO Login(IUserDTO userDTO)
        {
            using (var context = new BufferOverflowDBEntities())
            {
                var user = context.User.SingleOrDefault(u => u.Email == userDTO.Email);
                if (user != null)
                {
                    string password = user.Password;
                    string Decrypted = EncryptionAndDecryption.Decrypt(password, EncryptionAndDecryption.EncryptionKey);
                    bool isValid = (userDTO.Password == Decrypted);
                    //IUserDTO userDto = null;
                    if (isValid)
                    {
                        EntityConverter.FillDTOFromEntity(user, userDTO);
                    }
                }
                return (userDTO.Id != 0) ? userDTO: null;
                
            }
        }
    }
}
