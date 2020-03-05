using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{

    //ImagePost derives from Post and adds a property (ImageURL) and two constructors
    class ImagePost: Post
    {
        public string ImageURL { get; set; }

        public ImagePost() { }

        public ImagePost ( string title, string sendByUsername, string imageUrl, bool isPublic)
        {
            //The following properties and the GetNextID method are inherited from Post
            this.ID = GetNextID();
            this.Title = title;
            this.SendByUsername = sendByUsername;
            this.IsPublic = isPublic;

            //Property ImageUrl is a member of ImagePost, but not of Post
            this.ImageURL = imageUrl;
        }

    }
}
