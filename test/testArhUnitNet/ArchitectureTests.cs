using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Fluent.Slices;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using Contracts;
using Domain.Entities;
using Domain.Repository.Abstractions;
using Presentation;
using Services.Abstractions;
using Services;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using Microsoft.AspNetCore.Identity.Data;

namespace TestArchUnitNet;

public partial class ArchitectureTests
{
    private static readonly Architecture _architecture =
        new ArchLoader().LoadAssemblies(
            System.Reflection.Assembly.Load("Contracts"),
            System.Reflection.Assembly.Load("Domain"),
            System.Reflection.Assembly.Load("Services.Abstractions"),
            System.Reflection.Assembly.Load("Services"),
            System.Reflection.Assembly.Load("Persistance"),
            System.Reflection.Assembly.Load("Presentation"),
            System.Reflection.Assembly.Load("Web")
        ).Build();

    //Nomage
    [Fact]
    public void NamingForServices()
    {
        var servicesNamingRule =
            Classes().That().ResideInNamespace("Services")
            .Should().HaveNameContaining("Service");

        servicesNamingRule.Check(_architecture);
    }

    [Fact]
    public void NamingForPresentation()
    {
        var presentationNamingRule =
                     Classes().That().ResideInNamespace("Presentation")
                    .Should().HaveFullNameContaining("Controller");
        presentationNamingRule.Check(_architecture);
    }

    //Appartenance
    [Fact]
    public void ControllersBelongsToPresentation()
    {
        IArchRule rule = Classes().That().HaveFullNameContaining("Controllers")
            .Should().ResideInNamespace("Presentation");

        rule.Check(_architecture);
    }

    //Implementations: 1 seule responsabilité => 1 implementation SRP
    [Fact]
    public void interfacesRule()
    {
        IArchRule rule = Types().That().Are("CommandeService")
            .Should().ImplementInterface("IFacturationService");// ICommandeService
            //.And();

        rule.Check(_architecture);
    }

    //Dependances
    [Fact]
    public void DomainHasNoDependencies()
    {
        var domain = Types().That().ResideInAssembly("1.Domain");
        IArchRule domainFree = domain
            .Should().NotDependOnAny(Types().That().ResideInAssembly("Services"))
           //.And(). NotDependOnAny(Types().That().ResideInAssembly("Presentation"))
           .Because("Domain is dependance free");
        domainFree.Check(_architecture);
    }

    [Fact]
    public void ServicesAbstractionsDependencies()
    {
        IArchRule servicesAbstractions = 
            Types().That().ResideInNamespace("Services.Abstractions")
           .Should().DependOnAny(Types().That().ResideInNamespace("Contracts"));
        servicesAbstractions.Check(_architecture);
    }

    [Fact]
    public void ServicesAbstractions()
    {
        IArchRule servicesAbstractions = Types().That().ResideInNamespace("Services.Abstractions")
           .Should().DependOnAny(Types().That().ResideInNamespace("Contracts"));
        servicesAbstractions.Check(_architecture);
    }

    //Interfaces()

    //Methods

    //Cycles => Slices() KO ??



    //[Fact]
    //public void Cycles()
    //{
    //    IArchRule rule = Slice().Matching("Onion.(*)")
    //        .Should()
    //        .BeFreeOfCycles();

    //    rule.Check(_architecture);
    //}

}
