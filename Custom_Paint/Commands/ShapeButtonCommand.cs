using Custom_Paint.Services;
using Custom_Paint.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Paint.Commands
{
    public class ShapeButtonCommand : CommandBase
    {
        private PaintViewModel _viewModel;

        public ShapeButtonCommand(PaintViewModel viewModel)
        {
            _viewModel = viewModel; 
        }
        public override void Execute(object? parameter)
        {
            if(parameter != null) {
                string choose = (string)parameter;
                _viewModel.Preview = _viewModel.Factory.CreateShape(choose);
            }
        }
    }
}
