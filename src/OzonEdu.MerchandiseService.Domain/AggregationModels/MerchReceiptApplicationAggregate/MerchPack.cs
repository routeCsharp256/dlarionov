using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    public class MerchPack : Entity
    {
        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при устройстве на работу.
        /// </summary>
        public static MerchPack WelcomePack = new(10, nameof(WelcomePack), new List<MerchPosition>());
        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при посещении конференции в качестве слушателя.
        /// </summary>
        public static MerchPack ConferenceListenerPack = new(20, nameof(ConferenceListenerPack), new List<MerchPosition>());
        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при посещении конференции в качестве спикера.
        /// </summary>
        public static MerchPack ConferenceSpeakerPack = new(30, nameof(ConferenceSpeakerPack), new List<MerchPosition>());
        /// <summary>
        /// Набор мерча, выдаваемый сотруднику при успешном прохождении испытательного срока.
        /// </summary>
        public static MerchPack ProbationPeriodEndingPack = new(40, nameof(ProbationPeriodEndingPack), new List<MerchPosition>());
        /// <summary>
        /// Набор мерча, выдаваемый сотруднику за выслугу лет.
        /// </summary>
        public static MerchPack VeteranPack = new(50, nameof(VeteranPack), new List<MerchPosition>());

        public MerchPack(int id, string name, IReadOnlyList<MerchPosition> merchPositionCollection)
        {
        }
    }
}
