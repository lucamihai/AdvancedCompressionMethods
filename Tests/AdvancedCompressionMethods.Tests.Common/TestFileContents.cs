using System.Diagnostics.CodeAnalysis;

namespace AdvancedCompressionMethods.Tests.Common
{
    [ExcludeFromCodeCoverage]
    public static class TestFileContents
    {
        public const string FileTextContents1 = "Aa Bb Cc Dd Ee Ff Gg Hh Ii Jj Kk Ll Mm Nn Oo Pp Qq Rr Ss Tt Uu Vv Ww Xx Yy Zz";

        public const string FileTextContents2 = 
            @"Just some filler text
and some more filler text
and another row just for good measure";

        public const string FileTextContents3 =
            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce at sem sodales, suscipit lorem eu, tempus turpis. Sed porta lorem lacinia ante aliquam mattis nec at nunc. Nulla ac libero faucibus quam facilisis mattis in interdum massa. Aliquam non elit pretium, varius erat sed, finibus magna. In laoreet nisi et est fermentum vestibulum. Morbi mollis tempor nulla in porttitor. Etiam tincidunt dolor sodales turpis tempor, non porta metus bibendum.

Integer non sagittis sapien. Praesent dapibus elit nec porttitor fermentum. Aliquam et vulputate dolor. Nullam faucibus, augue non bibendum luctus, neque nibh porta massa, ut ornare erat est in turpis. In sit amet diam id urna consequat blandit. Etiam venenatis metus quis sapien maximus varius sed quis diam. Vivamus lacus lacus, congue vel orci nec, porta accumsan ipsum. Sed vehicula ultricies fermentum. Suspendisse potenti.";
    }
}