using BfkPortal.Core.Models;
using BfkPortal.Persistence;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BfkPortal.PersistenceTest
{
    public class GenericRepositoryTest
    {
        [Fact]
        public void Add_ValidRole_Added()
        {
            ClearDatabase();

            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Roles.Add(new Role
                {
                    Name = "AdminBfk",
                    Entitlements = new List<Entitlement>()
                });

                unitOfWork.SaveChangesAsync().Wait();

                var result = unitOfWork.Roles.All();
                Assert.Single(result);
                Assert.Equal("AdminBfk", result.First().Name);
            }
        }

        [Fact]
        public void AddRange_ValidRoles_Added()
        {
            ClearDatabase();

            using (var unitOfWork = new UnitOfWork())
            {
                var roles = new[]
                {
                    new Role
                    {
                        Name = "UserBwst",
                        Entitlements = new List<Entitlement>()
                    },
                    new Role
                    {
                        Name = "AdminBwst",
                        Entitlements = new List<Entitlement>()
                    }
                };
                unitOfWork.Roles.AddRange(roles);
                unitOfWork.SaveChangesAsync().Wait();

                var result = unitOfWork.Roles.All();
                Assert.Equal(2, result.Count());
                Assert.Equal("UserBwst", result.First().Name);
            }
        }

        [Fact]
        public void Remove_ValidRole_Removed()
        {
            ClearDatabase();

            using (var unitOfWork = new UnitOfWork())
            {
                var role = new Role
                {
                    Name = "ObserverBwst",
                    Entitlements = new List<Entitlement>()
                };
                unitOfWork.Roles.Add(role);
                unitOfWork.SaveChangesAsync().Wait();

                unitOfWork.Roles.Remove(role);
                unitOfWork.SaveChangesAsync().Wait();

                Assert.Empty(unitOfWork.Roles.All());
            }
        }

        [Fact]
        public void RemoveRange_ValidRoles_Removed()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                ClearDatabase();

                var roles = new[]
                {
                    new Role
                    {
                        Name = "UserBwst",
                        Entitlements = new List<Entitlement>()
                    },
                    new Role
                    {
                        Name = "AdminBwst",
                        Entitlements = new List<Entitlement>()
                    }
                };
                unitOfWork.Roles.AddRange(roles);
                unitOfWork.SaveChangesAsync().Wait();

                unitOfWork.Roles.RemoveRange(roles);
                unitOfWork.SaveChangesAsync().Wait();

                Assert.Empty(unitOfWork.Roles.All());
            }
        }

        [Fact]
        public void Find_FindUserBwst_Found()
        {
            ClearDatabase();

            using (var unitOfWork = new UnitOfWork())
            {
                var role = new Role
                {
                    Name = "AdminBfk",
                    Entitlements = new List<Entitlement>()
                };
                unitOfWork.Roles.Add(role);

                unitOfWork.SaveChangesAsync().Wait();

                var result = unitOfWork.Roles.FindAsync(role.Id).Result;

                Assert.Equal("AdminBfk", result.Name);
            }
        }

        private void ClearDatabase()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                //unitOfWork.DeleteDatabaseAsync().Wait();
                unitOfWork.CreateDatabaseAsync().Wait();
            }
        }
    }
}
