using Api.Learning.DataAccess.Context;
using Api.Learning.DataAccess.Repository.Course;
using Api.Learning.DataAccess.Repository.Student;
using Api.Learning.DataAccess.Repository.Teacher;
using Api.Learning.Services.Services.Courses.CreateCourseService;
using Api.Learning.Services.Services.Courses.ListarCourseService;
using Api.Learning.Services.Services.Courses.ShowCourseService;
using Api.Learning.Services.Services.Students.CreateStudentService;
using Api.Learning.Services.Services.Students.DeleteStudentService;
using Api.Learning.Services.Services.Students.ListarStudentService;
using Api.Learning.Services.Services.Students.ShowStudentService;
using Api.Learning.Services.Services.Students.UpdateStudentService;
using Api.Learning.Services.Services.Teachers.CreateTeacherService;
using Api.Learning.Services.Services.Teachers.DeleteTeacherService;
using Api.Learning.Services.Services.Teachers.ListTeachersService;
using Api.Learning.Services.Services.Teachers.ShowTeacherService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Learning.Api
{
    public class DependencyInjection
    {
        public static void Config(IServiceCollection services, IConfiguration configuration)
        {

            #region CONTEXTS


            services
                .AddDbContext<ApiLearningContext>(op =>
                {
                    op.UseNpgsql(
                        configuration.GetConnectionString("MyCourseDB"),
                        x => x.MigrationsAssembly(typeof(ApiLearningContext).Assembly.FullName)
                        );

                });

            #endregion

            #region TABLES/ENTITIES
            #endregion

            #region REPOSITORIES
            services.AddScoped<IStudentRepository,StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            #endregion

            #region SERVICES

            services.AddScoped<ICreateStudentServices, CreateStudentServices>();
            services.AddScoped<IListarStudentService, ListarStudentService>();
            services.AddScoped<IShowStudentService, ShowStudentService>();
            services.AddScoped<IDeleteStudentService, DeleteStudentService>();
            services.AddScoped<IUpdateStudentService,UpdateStudentService>();

            services.AddScoped<IDeleteTeacherService, DeleteTeacherService>();
            services.AddScoped<ICreateTeacherService, CreateTeacherService>();
            services.AddScoped<IShowTeacherService, ShowTeacherService>();
            services.AddScoped<IListTeacherService, ListTeacherService>();

            services.AddScoped<ICreateCourseService, CreateCourseService>();
            services.AddScoped<IListarCourser, ListarCourser>();
            services.AddScoped<IShowCourseService, ShowCourseService>();
            #endregion


        }
    }
}
