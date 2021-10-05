using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorProject.Shared;

namespace BlazorProject.Server.Models
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> Search(string name, Gender? gender);
        Task<IEnumerable<Profile>> GetProfiles();
        Task<Profile> GetProfile(int profileId);
        Task<Profile> GetProfileByEmail(string email);
        Task<Profile> AddProfile(Profile profile);
        Task<Profile> UpdateProfile(Profile profile);
        //Task DeleteProfile(int profileId);
    }
}
