using BlazorProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Models
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AppDbContext appDbContext;

        public ProfileRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Profile> AddProfile(Profile profile)
        {
            var result = await appDbContext.Profiles.AddAsync(profile);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteProfile(int profileId)
        {
            var result = await appDbContext.Profiles
                .FirstOrDefaultAsync(e => e.ProfileId == profileId);
            if (result != null)
            {
                appDbContext.Profiles.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Profile> GetProfile(int profileId)
        {
            return await appDbContext.Profiles
                .FirstOrDefaultAsync(e => e.ProfileId == profileId);

            // .Include(e => e.Messages)
        }

        public Task<Profile> GetProfileByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Profile>> GetProfiles()
        {
            return await appDbContext.Profiles.ToListAsync();
        }

        public async Task<IEnumerable<Profile>> Search(string alias, Gender? gender)
        {
            IQueryable<Profile> query = appDbContext.Profiles;

            if (!string.IsNullOrEmpty(alias))
                query = query.Where(e => e.Alias.Contains(alias));

            if (gender != null)
            {
                query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Profile> UpdateProfile(Profile profile)
        {
            var result = await appDbContext.Profiles
                .FirstOrDefaultAsync(e => e.ProfileId == profile.ProfileId);

            if (result != null)
            {
                result.Alias = profile.Alias;
                result.Postal = profile.Postal;
                result.Gender = profile.Gender;
                result.BirthDate = profile.BirthDate;
                result.PhotoPath = profile.PhotoPath;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
