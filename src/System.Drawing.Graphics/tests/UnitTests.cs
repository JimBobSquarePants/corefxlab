// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using Xunit;
using System.Drawing.Graphics;
using System.IO;


public partial class GraphicsUnitTests
{

    [Fact]
    public static void Test()
    {
        Image dog1 = Image.Load(@"C:\Users\t-xix\Pictures\dog1.jpg");
        Image cat2 = Image.Load(@"C:\Users\t-xix\Pictures\cat2.jpg");
        Image blank = Image.Load(@"C:\Users\t-xix\Pictures\blankslide.jpg");
        Image blankdogsize = blank.Resize(dog1.WidthInPixels, dog1.HeightInPixels);

        blankdogsize.Draw(dog1, 10, 10);
        blankdogsize.WriteToFile(@"C:\Users\t-xix\Pictures\opacity.jpg");
    }

    [Fact]
    public static void WhenCreatingAnEmptyImageThenValidateAnImage()
    {
        ////create an empty 10x10 image
        Image emptyTenSquare = Image.Create(10, 10);
        ValidateImage(emptyTenSquare, 10, 10, PixelFormat.Argb);
    }
    private static void ValidateImage(Image image, int widthToCompare, int heightToCompare,
                               PixelFormat formatToCompare)
    {
        Assert.Equal(image.WidthInPixels, widthToCompare);
        Assert.Equal(image.HeightInPixels, heightToCompare);
        //Assert.NotNull(image.PixelData);
    }

    /* Tests Create Method */
    [Fact]
    public void WhenCreatingABlankImageWithNegativeHeightThenThrowException()
    {
        Exception exception = Assert.Throws<InvalidOperationException>(() => Image.Create(1, -1));
        Assert.Equal("Parameters for creating an image must be positive integers.", exception.Message);
    }
    [Fact]
    public void WhenCreatingABlankImageWithNegativeWidthThenThrowException()
    {
        Exception exception = Assert.Throws<InvalidOperationException>(() => Image.Create(-1, 1));
        Assert.Equal("Parameters for creating an image must be positive integers.", exception.Message);
    }
    [Fact]
    public void WhenCreatingABlankImageWithNegativeSizesThenThrowException()
    {
        Exception exception = Assert.Throws<InvalidOperationException>(() => Image.Create(-1, -1));
        Assert.Equal("Parameters for creating an image must be positive integers.", exception.Message);
    }
    [Fact]
    public void WhenCreatingABlankImageWithZeroHeightThenThrowException()
    {
        Exception exception = Assert.Throws<InvalidOperationException>(() => Image.Create(1, 0));
        Assert.Equal("Parameters for creating an image must be positive integers.", exception.Message);
    }
    [Fact]
    public void WhenCreatingABlankImageWithZeroWidthThenThrowException()
    {
        Exception exception = Assert.Throws<InvalidOperationException>(() => Image.Create(0, 1));
        Assert.Equal("Parameters for creating an image must be positive integers.", exception.Message);
    }
    [Fact]
    public void WhenCreatingABlankImageWithZeroParametersThenThrowException()
    {
        Exception exception = Assert.Throws<InvalidOperationException>(() => Image.Create(0, 0));
        Assert.Equal("Parameters for creating an image must be positive integers.", exception.Message);
    }
    [Fact(Skip = "Not Implemented yet...")]
    public void WhenCreatingAnImageFromAValidFileGiveAValidImage()
    {
        string filepath = "";
        Image fromFile = Image.Load(filepath);
        //arbitraily passing in pixelformat.argb now and 0, 0
        ValidateImage(fromFile, 0, 0, PixelFormat.Argb);
    }

    //File I/O should be returning exceptions --> HOW TO DO THIS?!!?
    //Invalid file path
    //Path not found
    //Path not an image
    /* Tests Load(filepath) method */
    [Fact(Skip = "Not Implemented yet...")]
    public void WhenCreatingAnImageFromAMalformedPathThenThrowException()
    {
        //place holder string to demonstrate what would be the error case
        string invalidFilepath = "C://";
        Exception exception = Assert.Throws<FileNotFoundException>(() => Image.Load(invalidFilepath));
        Assert.Equal("Malformed file path given", exception.Message);
    }
    [Fact(Skip = "Not Implemented yet...")]
    public void WhenCreatingAnImageFromAnUnfoundPathThenThrowException()
    {
        //place holder string to demonstrate what would be the error case
        string invalidFilepath = "C:\\Documents\\Documents\\Documents\\documents.jpeg";
        Exception exception = Assert.Throws<FileNotFoundException>(() => Image.Load(invalidFilepath));
        Assert.Equal("Malformed file path given", exception.Message);
    }
    [Fact]
    public void WhenCreatingAnImageFromAFileTypeThatIsNotAnImageThenThrowException()
    {
        //place holder string to demonstrate what would be the error case
        string invalidFilepath = "C:\\Documents\\doc.docx";
        Exception exception = Assert.Throws<FileLoadException>(() => Image.Load(invalidFilepath));
        Assert.Equal("File type not supported.", exception.Message);
    }

    /* Tests Load(stream) mehtod*/
    [Fact(Skip = "Not Implemented yet...")]
    public void WhenCreatingAnImageFromAValidStreamThenGiveValidImage()
    {
        //placeholder stream
        Stream stream = null;
        Image fromStream = Image.Load(stream);
        //arbitraily passing in pixelformat.argb now and 0, 0
        ValidateImage(fromStream, 0, 0, PixelFormat.Argb);
    }
    [Fact(Skip = "Not Implemented yet...")]
    public void WhenCreatingAnImageFromAnInvalidStreamThenThrowException()
    {
        Stream stream = null;
        Exception exception = Assert.Throws<InvalidOperationException>(() => Image.Load(stream));
        Assert.Equal("Stream given is not valid", exception.Message);
    }

    /* Test Resize */
    [Fact]
    public void WhenResizingEmptyImageThenGiveAValidatedResizedImage()
    {
        Image emptyResizeSquare = Image.Create(100, 100);
        emptyResizeSquare = emptyResizeSquare.Resize(10, 10);
        //arbitraily passing in pixelformat.argb now 
        ValidateImage(emptyResizeSquare, 10, 10, PixelFormat.Argb);
    }
    [Fact(Skip = "Not Implemented yet...")]
    public void WhenResizingImageLoadedFromFileThenGiveAValidatedResizedImage()
    {
        string filepath = "";
        Image fromFileResizeSquare = Image.Load(filepath);
        fromFileResizeSquare.Resize(10, 10);
        //arbitraily passing in pixelformat.argb now 
        ValidateImage(fromFileResizeSquare, 10, 10, PixelFormat.Argb);
    }
    [Fact(Skip = "Not Implemented yet...")]
    public void WhenResizingImageLoadedFromStreamThenGiveAValidatedResizedImage()
    {
        Stream stream = null;
        Image fromStreamResizeSquare = Image.Load(stream);
        fromStreamResizeSquare.Resize(10, 10);
        //arbitraily passing in pixelformat.argb now 
        ValidateImage(fromStreamResizeSquare, 10, 10, PixelFormat.Argb);
    }

    /* Testing Resize parameters */
    [Fact]
    public void WhenResizingImageGivenNegativeHeightThenThrowException()
    {
        Image img = Image.Create(1, 1);
        //Not sure if this is how to do this
        Exception exception = Assert.Throws<InvalidOperationException>(() => img.Resize(-1, 1));
        Assert.Equal("Parameters for resizing an image must be positive integers.", exception.Message);
    }
    [Fact]
    public void WhenResizingImageGivenNegativeWidthThenThrowException()
    {
        Image img = Image.Create(1, 1);
        //Not sure if this is how to do this
        Exception exception = Assert.Throws<InvalidOperationException>(() => img.Resize(1, -1));
        Assert.Equal("Parameters for resizing an image must be positive integers.", exception.Message);
    }
    [Fact]
    public void WhenResizingImageGivenNegativeSizesThenThrowException()
    {
        Image img = Image.Create(1, 1);
        //Not sure if this is how to do this
        Exception exception = Assert.Throws<InvalidOperationException>(() => img.Resize(-1, -1));
        Assert.Equal("Parameters for resizing an image must be positive integers.", exception.Message);
    }
    [Fact]
    public void WhenResizingImageGivenZeroHeightThenThrowException()
    {
        Image img = Image.Create(1, 1);
        //Not sure if this is how to do this
        Exception exception = Assert.Throws<InvalidOperationException>(() => img.Resize(0, 1));
        Assert.Equal("Parameters for resizing an image must be positive integers.", exception.Message);
    }
    [Fact]
    public void WhenResizingImageGivenZeroWidthThenThrowException()
    {
        Image img = Image.Create(1, 1);
        //Not sure if this is how to do this
        Exception exception = Assert.Throws<InvalidOperationException>(() => img.Resize(1, 0));
        Assert.Equal("Parameters for resizing an image must be positive integers.", exception.Message);
    }
    [Fact]
    public void WhenResizingImageGivenZeroSizesThenThrowException()
    {
        Image img = Image.Create(1, 1);
        //Not sure if this is how to do this
        Exception exception = Assert.Throws<InvalidOperationException>(() => img.Resize(0, 0));
        Assert.Equal("Parameters for resizing an image must be positive integers.", exception.Message);
    }


    [Fact]
    public void WhenWritingAnImageToAValidFileWriteToAValidFile()
    {
        Image fromFile = Image.Create(10, 10);
        fromFile.WriteToFile(@"C:\Users\t-xix\Pictures\TEST.jpg");
    }

}




