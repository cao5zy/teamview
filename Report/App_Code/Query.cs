﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using BugInfoManagement;
using BugInfoManagement.DaoImpl;
using BugInfoManagement.Dao;
using BugInfo.Common;
using BugInfo.Common.Logs;
using BugInfoManagement.Entity;
using Autofac;

public class QueryData
{
    Autofac.IContainer mContainer;
    public QueryData()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<BugInfoManagementImpl>().As<IBugInfoManagement>().PropertiesAutowired().InstancePerDependency();
        builder.RegisterType<JIRAImporter>().As<IItemImporter>();
        builder.RegisterModule<LogsModule>();
        builder.RegisterType<DBProvider>().As<IDbProvider>();
        mContainer = builder.Build();
    }

    public List<BugInfoEntity> query(string[] programmer, string bugNum, string version, string description,int ? priority, string bugState)
    {
        DBProvider dbProvider = new DBProvider();
        TaskRecordParser recorder = new TaskRecordParser();
        IBugInfoManagement test = mContainer.Resolve<IBugInfoManagement>();
        List<BugInfoEntity> result = test.QueryByParameter(programmer, bugNum, version, description, priority, bugState);
        return result;
    }
}
