using System.ComponentModel;

namespace Supermarket.Entites.Enums
{
    public enum UnitOfMeasurement
    {
        [Description("UN")]
        Unity = 1,

        [Description("MG")]
        Milligram = 2,

        [Description("G")]
        GRam = 3,

        [Description("KG")]
        Kilogram = 4,

        [Description("L")]
        Liter = 5
    }
}
