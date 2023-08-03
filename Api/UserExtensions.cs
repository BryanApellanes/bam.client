using Bam.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    internal static class UserExtensions
    {
        public static AppUser ToAppUser(this User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return new AppUser
            {
                Id = user.Id,
                Credentials = new AppUserCredentials
                {
                    UserName = user.Profile.Email
                }
            };
        }
    }
}
