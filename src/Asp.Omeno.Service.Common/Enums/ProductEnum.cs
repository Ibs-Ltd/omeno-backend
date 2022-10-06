using System;

namespace Asp.Omeno.Service.Common.Enums
{
    public static class ProductEnum
    {
        public static Guid PRODUCT_STATUS_INPROGRESS = Guid.Parse("7cea5e8b-7f9f-4db6-8191-43cd170787e5");
        public static Guid PRODUCT_STATUS_SOLD = Guid.Parse("d9edce4c-4f7f-4a71-91c7-b2b4a5c4bf7f");
        public static Guid PRODUCT_TYPE_GIVEAWAY = Guid.Parse("0c121d33-f2ac-4306-8990-bedc62c19062");

        public static Guid PRODUCT_STEP_CURRENT = Guid.Parse("d57e7821-d76f-4de6-8ac6-efd98d827a59");
        public static Guid PRODUCT_STEP_UPCOMING = Guid.Parse("ac5e1ee7-d4d3-48b8-8559-249ccf65c131");


    }
}
