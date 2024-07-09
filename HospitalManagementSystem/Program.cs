﻿using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Services;
using ApplicationDotnetAssignment1.UnitOfWork.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationDotnetAssignment1;
class Program
{
    static void Main(string[] args)
    {
        var context = new HospitalSystemContext();
        LoginService loginService = new LoginService();

        loginService.Login(0, "", context);
    }
}
