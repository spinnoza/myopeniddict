using AuthServer.Data;
using Microsoft.AspNetCore.Identity;

namespace AuthServer
{
    public class UserSeeder
    {
        private readonly IServiceProvider _serviceProvider;

        public UserSeeder(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 这个方法不好使
        /// </summary>
        /// <returns></returns>
        public async Task OptionAsync()
        {

            await using var scope = _serviceProvider.CreateAsyncScope();
            var user_manager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            ApplicationUser user = new ApplicationUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "123456"
            };

            await user_manager.CreateAsync(user);

            await user_manager.AddPasswordAsync(user, "123456");

            
        }


    }
}
