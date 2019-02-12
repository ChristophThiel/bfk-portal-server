using BfkPortal.Core.Models;
using BfkPortal.Persistence;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BfkPortal.PersistenceTest
{
    public class GenericRepositoryTest
    {
        [Fact]
        public async Task Add_ValidRole_Added()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var role = new Role { Name = "AdminTest" };
                unitOfWork.Roles.Add(role);
                await unitOfWork.SaveChangesAsync();

                // Check if role is saved in database
                var roles = unitOfWork.Roles.All();
                Assert.Equal(role.Name, roles.FirstOrDefault(r => r.Name == role.Name).Name);
            }
        }

        [Fact]
        public async Task AddRange_ValidRoles_Added()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var roles = new []
                {
                    new Role {Name = "UserTest"},
                    new Role {Name = "ObserverTest"}
                };
                unitOfWork.Roles.AddRange(roles);
                await unitOfWork.SaveChangesAsync();

                var check = unitOfWork.Roles.All();
                Assert.True(roles.All(r => check.Contains(r)));
            }
        }

        [Fact]
        public async Task All_GetAll()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var rolesAmount = unitOfWork.Roles.All().Count();
                await Add_ValidRole_Added();
                var newRolesAmount = unitOfWork.Roles.All().Count();

                Assert.Equal(rolesAmount + 1, newRolesAmount);
            }
        }

        [Fact]
        public async Task Find_Role_NotNull()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var role = new Role { Name = "FindTest" };
                unitOfWork.Roles.Add(role);
                await unitOfWork.SaveChangesAsync();

                var findRole = await unitOfWork.Roles.FindAsync(role.Id);
                Assert.NotNull(findRole);
                Assert.Equal(role.Id, findRole.Id);
            }
        }

        [Fact]
        public async Task Find_Role_Null()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var findRole = await unitOfWork.Roles.FindAsync(int.MaxValue);
                Assert.Null(findRole);
            }
        }

        [Fact]
        public async Task Remove_ValidRole_Removed()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var role = new Role { Name = "RemoveTest" };
                unitOfWork.Roles.Add(role);
                await unitOfWork.SaveChangesAsync();

                unitOfWork.Roles.Remove(role);
                await unitOfWork.SaveChangesAsync();

                Assert.Null((await unitOfWork.Roles.FindAsync(role.Id)));
            }
        }

        [Fact]
        public async Task RemoveRange_ValidRoles_Removed()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var roles = new[]
{
                    new Role {Name = "RemoveRangeTest"},
                    new Role {Name = "RemoveRangeTest2"}
                };
                unitOfWork.Roles.AddRange(roles);
                await unitOfWork.SaveChangesAsync();

                unitOfWork.Roles.RemoveRange(roles);
                await unitOfWork.SaveChangesAsync();

                Assert.DoesNotContain(unitOfWork.Roles.All(), r => roles.Contains(r));
            }
        }

        [Fact]
        public async Task Update_Role_Updated()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var role = new Role { Name = "UpdateTest" };
                unitOfWork.Roles.Add(role);
                await unitOfWork.SaveChangesAsync();

                role = await unitOfWork.Roles.FindAsync(role.Id);
                role.Name = "UpdatedTest";
                unitOfWork.Roles.Update(role);
                await unitOfWork.SaveChangesAsync();

                var roles = unitOfWork.Roles.All();
                Assert.Contains(roles, r => r.Name == role.Name);
            }
        }

        [Fact]
        public async Task UpdateRange_Roles_Updated()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var roles = new[]
{
                    new Role {Name = "UpdateRangeTest"},
                    new Role {Name = "UpdateRangeTest2"}
                };
                unitOfWork.Roles.AddRange(roles);
                await unitOfWork.SaveChangesAsync();
                
                foreach (var role in roles)
                    role.Name.Replace("Update", "Updated");

                unitOfWork.Roles.UpdateRange(roles);
                await unitOfWork.SaveChangesAsync();

                Assert.Contains(unitOfWork.Roles.All(), r => roles.Contains(r));
            }
        }
    }
}
