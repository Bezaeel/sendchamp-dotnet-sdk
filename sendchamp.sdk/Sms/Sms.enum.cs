using System.ComponentModel;

namespace sendchamp.sdk.Sms.Enums
{
    public enum SendChampUseCase
    {
        [Description("TRANSACTIONAL")]
        TRANSACTIONAL,

        [Description("MARKETING")]
        MARKETING,

        [Description("TRANSACTION & MARKETING")]
        TRANSACTION_AND_MARKETING
    }

    public enum SendChampRoutes
    {
        [Description("DND")]
        DND,

        [Description("NON_DND")]
        NON_DND,

        [Description("INTERNATIONAL")]
        INTERNATIONAL
    }
}
