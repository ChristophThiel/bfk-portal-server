using System.Text;
using BfkPortal.Core.Models;
using BfkPortal.Persistence;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Authorization;
using BfkPortal.Web.Authorization.Requirements;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.Services;
using BfkPortal.Web.Services.Converters;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BfkPortal.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
            {
                // TODO Remove this
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration["Issuer"],
                    ValidAudience = Configuration["Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Key"])),
                    RequireExpirationTime = false
                };
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Constants.OwnerOfAppointmentPolicy, policy => policy.Requirements.Add(new OwnerOfAppointmentRequirement()));
                options.AddPolicy(Constants.FreeAppointmentPolicy, policy => policy.Requirements.Add(new FreeAppointmentRequirement()));
            });
            
            services.AddScoped<IUnitOfWork, UnitOfWork>(serviceProvider => new UnitOfWork());

            // Converters
            services.AddScoped<IConverter<UserViewModel, User>, UserViewModelToUserConverter>();
            services.AddScoped<IConverter<User, UserDto>, UserToUserDtoConverter>();
            // services.AddScoped<IConverter<OrganisationViewModel, Organisation>, OrganisationViewModelToOrganisationConverter>();
            services.AddScoped<IConverter<Organisation, OrganisationDto>, OrganisationToOrganisationDtoConverter>();
            services.AddScoped<IConverter<AppointmentViewModel, Appointment>, AppointmentViewModelToAppointmentConverter>();
            services.AddScoped<IConverter<Appointment, AppointmentDto>, AppointmentToAppointmentDtoConverter>();
            /*services.AddScoped<IConverter<OfferViewModel, Offer>, OfferViewModelToOfferConverter>();
            services.AddScoped<IConverter<Offer, OfferDto>, OfferToOfferDtoConverter>(); */
            
            // Services
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            
            // Policy Handlers
            services.AddTransient<IAuthorizationHandler, OwnerOfAppointmentHandler>();
            services.AddTransient<IAuthorizationHandler, FreeAppointmentHandler>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
