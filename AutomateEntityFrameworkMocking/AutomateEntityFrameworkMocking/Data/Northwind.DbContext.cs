﻿

//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace AutomateEntityFrameworkMocking.Data
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

using AutomateEntityFrameworkMocking.Domain;



public partial class NorthwindEntities : DbContext, IDbContext
{
    public NorthwindEntities()
        : base("name=NorthwindEntities")
    {

        this.Configuration.LazyLoadingEnabled = false;

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Category> Categories { get; set; }
	
	IQueryable<Category> IDbContext.Categories
		{
            get { return this.Categories; }
		}

    public virtual DbSet<Customer> Customers { get; set; }
	
	IQueryable<Customer> IDbContext.Customers
		{
            get { return this.Customers; }
		}

    public virtual DbSet<Employee> Employees { get; set; }
	
	IQueryable<Employee> IDbContext.Employees
		{
            get { return this.Employees; }
		}

    public virtual DbSet<Order_Detail> Order_Details { get; set; }
	
	IQueryable<Order_Detail> IDbContext.Order_Details
		{
            get { return this.Order_Details; }
		}

    public virtual DbSet<Order> Orders { get; set; }
	
	IQueryable<Order> IDbContext.Orders
		{
            get { return this.Orders; }
		}

    public virtual DbSet<Product> Products { get; set; }
	
	IQueryable<Product> IDbContext.Products
		{
            get { return this.Products; }
		}

    public virtual DbSet<Shipper> Shippers { get; set; }
	
	IQueryable<Shipper> IDbContext.Shippers
		{
            get { return this.Shippers; }
		}

    public virtual DbSet<Supplier> Suppliers { get; set; }
	
	IQueryable<Supplier> IDbContext.Suppliers
		{
            get { return this.Suppliers; }
		}

}

}

