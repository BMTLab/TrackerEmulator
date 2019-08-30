//  TrackerEmulator.TrackerEmulator
//  Created by Nikita Neverov at 28.08.2019 16:53

using TrackerEmulator.ViewModels;
using Color = System.Drawing.Color;

namespace TrackerEmulator.Entites
{
    public class ImeiItem : BaseViewModel
    {
        #region Fields
        public static Color ItemSelectedColor = Color.Brown;
        public static Color ItemNonSelectedColor = Color.Transparent;
        public static Color ItemSelectedTextColor = Color.White;
        public static Color ItemNonSelectedTextColor = Color.Black;
        public static Color TextColorDefault = Color.Black;


        private Color _backgroundColor = ItemNonSelectedColor;
        private Color _textColor = TextColorDefault;

        private string _imei;
        private bool _isActive;
        #endregion


        #region Constructors
        public ImeiItem()
        {
        }
        #endregion


        #region Properties
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set
            {
                _backgroundColor = value;
                OnPropertyChanged();
            }
        }
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                OnPropertyChanged();
            }
        }

        public string Imei
        {
            get => _imei;
            set
            {
                _imei = value;
                OnPropertyChanged();
            }
        }

        public virtual bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                if (_isActive)
                {
                    BackgroundColor = ItemSelectedColor;
                    TextColor = ItemSelectedTextColor;
                }
                else
                {
                    BackgroundColor = ItemNonSelectedColor;
                    TextColor = ItemNonSelectedTextColor;
                }

                OnPropertyChanged();
            }
        }
        #endregion


        #region Operators
        public static implicit operator ImeiItem(string imeiString)
        {
            return new ImeiItem
            {
                Imei = imeiString
            };
        }

        public static explicit operator string(ImeiItem imeiItem)
        {
            return imeiItem.Imei;
        }
        #endregion


        #region Methods

        #endregion
    }
}
