using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Fluent.Slices;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using Domain.Repository.Abstractions;
using Presentation;
using Services.Abstractions;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace TestArhUnitNet;


public class ArchitectureTest
{    
    private static readonly Architecture _architecture =
        new ArchLoader().LoadAssemblies(
             System.Reflection.Assembly.Load("1.Domain"),
             System.Reflection.Assembly.Load("Contracts"),             
             System.Reflection.Assembly.Load("Services.Abstractions"),
             System.Reflection.Assembly.Load("Services"),
             System.Reflection.Assembly.Load("Persistance"),
             System.Reflection.Assembly.Load("Presentation"),
             System.Reflection.Assembly.Load("Web")
            )
        .Build();

    //Dependances
    [Fact]
    public void DomainHasNoDependencies()
    {
        Assert.Equal(1, 1);

         IArchRule domain = Types().That().ResideInAssembly("1.Domain")
            .Should().NotDependOnAny(Types().That().ResideInAssembly("Services"))
            .Because("Domain is dependance free");
        domain.Check(_architecture);
    }

    [Fact]
    public void DomainHasNoDependenciesFail()
    {
        IArchRule services = Types().That().ResideInAssembly("1.Domain")
           .Should().DependOnAny(Types().That().ResideInAssembly("Services"))
           .Because("Domain is dependance free");
        services.Check(_architecture);
    }

    [Fact]
    public void servicesAbstractions()
    {
        IArchRule servicesAbstractions = Types().That().ResideInNamespace("Services.Abstractions")
           .Should().DependOnAny(Types().That().ResideInNamespace("Contracts"));
        servicesAbstractions.Check(_architecture);
    }

    [Fact]
    public void servicesAbstractionsFail()
    {
        IArchRule servicesAbstractions = Types().That().ResideInNamespace("Services.Abstractions")
           .Should().NotDependOnAny(Types().That().ResideInNamespace("Contracts"));
        servicesAbstractions.Check(_architecture);
    }

    //Implementations
    [Fact]
    public void interfacesRule()
    {
        IArchRule rule = Classes().That().AreAssignableTo(typeof(ICommandeService))
            .Should().NotDependOnAny(Classes().That().AreAssignableTo(typeof(ILoginService)));

        rule.Check(_architecture);
    }

    //Nomage
    [Fact]
    public void NamingForServices()
    {
        IArchRule rule = Classes().That().ResideInAssembly("Services")
            .Should().HaveNameEndingWith("Service");

        rule.Check(_architecture);
    }

    [Fact]
    public void NamingForPresentation()
    {
        IArchRule rule = Classes().That().ResideInAssembly("Presentation")
            .Should().HaveNameEndingWith("Controller");

        rule.Check(_architecture);
    }

    //Appartenance
    [Fact]
    public void ControllersBelonToPresentation()
    {
        IArchRule rule = Classes().That().HaveNameContaining("Controller")
            .Should().ResideInNamespace(typeof(CommandeController).Namespace);
        
        rule.Check(_architecture);
    }

    //Cycles => Slices() KO ??
    //[Fact]
    //public void Cycles()
    //{
    //    IArchRule rule = Slice().Matching("Onion.(*)")
    //        .Should()
    //        .BeFreeOfCycles();

    //    rule.Check(_architecture);
    //}

    //Interfaces()

    //Methods

}
