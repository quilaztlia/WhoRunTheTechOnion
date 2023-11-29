using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

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

    //a Nomage
    [Fact]
    public void aNamingForPresentation()
    {
        var presentationNamingRule =
                     Classes().That().ResideInNamespace("Presentation")
                    .Should().HaveFullNameContaining("Controller");
        presentationNamingRule.Check(_architecture);
    }

    [Fact]
    public void aNamingForServices()
    {
        var servicesNamingRule =
            Classes().That().ResideInNamespace("Services")
            .Should().HaveNameContaining("Service");

        servicesNamingRule.Check(_architecture);
    }
    
    //b Appartenance
    [Fact]
    public void bControllersBelongsToPresentation()
    {
        IArchRule rule = Classes().That().HaveFullNameContaining("Controllers")
            .Should().ResideInNamespace("Presentation");

        rule.Check(_architecture);
    }

    //c Dependency projects
    [Fact]
    public void cServicesAbstractionsDependencies()
    {
        IArchRule servicesAbstractions =
            Types().That().ResideInNamespace("Services.Abstractions")
            .And().DoNotHaveNameContaining("Manager")
           .Should().DependOnAny(Types().That().ResideInNamespace("Contracts"));
        servicesAbstractions.Check(_architecture);
    }

    [Fact]
    public void cServicesDependencies()
    {
        IArchRule services = Types().That().ResideInNamespace("Services")
           .Should().DependOnAny(Types().That().ResideInNamespace("Services.Abstractions"));
              //.And().DependOnAny(Types().That().ResideInAssembly("Contracts"))
              //.And().DependOnAny(Types().That().ResideInAssembly("Domain"));
          // .AndShould().DependOnAny(Types().That().ResideInNamespace("Domain"));
        services.Check(_architecture);
    }

    //Depend
    [Fact]
    public void DomainHasNoDependencies()
    {
        var domain = Types().That().ResideInAssembly("Domain");
        IArchRule domainFree = domain
            .Should().NotDependOnAny(Types().That().ResideInAssembly("Services"))
            .AndShould().NotDependOnAny(Types().That().ResideInAssembly("Persistance"))
            .AndShould().NotDependOnAny(Types().That().ResideInAssembly("Presentation"))
            .AndShould().NotDependOnAny(Types().That().ResideInAssembly("Web"))
           .Because("Domain is dependance free");
        domainFree.Check(_architecture);
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
