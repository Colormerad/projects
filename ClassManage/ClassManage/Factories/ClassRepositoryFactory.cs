using ClassManage.Data;
using ClassManage.Data.ADO;
using ClassManage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassManage.Factories
{
    public class ClassRepositoryFactory
    {
        public static IClassRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "ADO":
                    return new ClassRepositoryADO();
                default:
                    throw new Exception("Could not find valid Repository Type configuration value");
            }

        }

    }
}