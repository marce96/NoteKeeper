using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using NoteKeeper.Models;
using NoteKeeper.ViewModels;
using System.Collections.Generic;
using NoteKeeper.Services;

namespace NoteKeeper.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        public Note _note { get; set; } = null;
        public IList<String> CourseList { get; set; }

        async void InitializeData()
        {
            var pluralsightDataStore = new MockTestingDataStore();
            CourseList = await pluralsightDataStore.GetCousesAsync();
            _note = new Note { Heading = "Test note", Text = "Text for a test note", Course = CourseList[0]};
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            InitializeData();

            // BindingContext = this.viewModel = viewModel;

            BindingContext = _note;
            NoteCourse.BindingContext = this;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            InitializeData();

            BindingContext = _note;
            NoteCourse.BindingContext = this;
        }

        public void Cancel_Clicked(object sender, EventArgs eventArgs)
        {
            DisplayAlert("Cancel option", "Cancel was selected", "Button 2", "Button 1");
        }

        public void Save_Clicked(object sender, EventArgs eventArgs)
        {
            DisplayAlert("Save option", "Save was selected", "Button 2", "Button 1");
        }

    }
}