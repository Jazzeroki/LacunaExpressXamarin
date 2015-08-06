using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using LacunaExpanseAPIWrapper.ParamsModels;

namespace LacunaExpress.ViewCells
{
    public class ParliamentProposalViewCell : ViewCell
    {
        public Label PropositionName = new Label();
        public Label PropositionDescription = new Label();
        StackLayout layout = new StackLayout();
        public ParliamentProposalViewCell()
        {
            PropositionName.SetBinding(Label.TextProperty, "Proposition");
            PropositionDescription.SetBinding(Label.TextProperty, "Explanation");

            layout.Children.Add(PropositionName);
            layout.Children.Add(PropositionDescription);
            View = layout;
        }
        
    }
}
