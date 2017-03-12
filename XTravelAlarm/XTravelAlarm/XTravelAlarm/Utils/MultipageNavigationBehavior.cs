using Prism.Navigation;
using System;
using Xamarin.Forms;

namespace XTravelAlarm.Utils
{
    public interface IMultiPageNavigationAware
    {
        void OnInternalNavigatedFrom(NavigationParameters navParams);
        void OnInternalNavigatedTo(NavigationParameters navParams);
    }

    public class MultipageNavigationBehavior : Behavior<MultiPage<Page>>
    {
        private Page _lastSelectedPage;
        private MultiPage<Page> _associatedObject;

        protected override void OnAttachedTo(MultiPage<Page> bindable)
        {
            _associatedObject = bindable;
            _associatedObject.CurrentPageChanged += CurrentPageChangedHandler;
        }

        protected override void OnDetachingFrom(MultiPage<Page> bindable)
        {
            _associatedObject.CurrentPageChanged -= CurrentPageChangedHandler;
        }

        private void CurrentPageChangedHandler(object sender, EventArgs e)
        {
            NavigationParameters navParams = new NavigationParameters();
            if (_lastSelectedPage != null)
            {
                IMultiPageNavigationAware lastPageAware = _lastSelectedPage.BindingContext as IMultiPageNavigationAware;
                if (lastPageAware != null)
                {
                    lastPageAware.OnInternalNavigatedFrom(navParams);
                }

                IMultiPageNavigationAware newPageAware = _associatedObject.CurrentPage.BindingContext as IMultiPageNavigationAware;
                if (newPageAware != null)
                {
                    newPageAware.OnInternalNavigatedTo(navParams);
                }
            }

            _lastSelectedPage = _associatedObject.CurrentPage;
        }
    }
}
