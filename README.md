# TransparencyMaker
Transparency Maker reads in a .jpg or .png and creates a Pixel Information Database, that can be manipulated in a language I invented called BQL or Bitmap Query language.

First thing that happens when an image is open is your file is parsed into a PixelInformationDatabase, aka PixelDatabase.

When the program starts, click the Start button to select your image. The image must be a Png or a Jpg.

<img src="https://github.com/DataJuggler/TransparencyMaker/blob/master/Docs/ScreenShot.png">

A Pixel Database is a List of PixelPixelInformation objects that contains properties about the object. To find the pixel information for any pixel, turn the Color Picker on.

<img src="https://github.com/DataJuggler/TransparencyMaker/blob/master/Docs/ColorPicker.png">

Once the Color Picker is turned on, click any pixel in your image and a Pixel Information Box pops up:

<img src="https://github.com/DataJuggler/TransparencyMaker/blob/master/Docs/PixelInfoBox.png">

The box contains the following properties:

Red - The Red value of RGB value. Value range is 0 - 255.

Green - The Green value of RGB value. Value range is 0 - 255.

Blue - The Blue value of RGB value. Value range is 0 - 255.

X - The horizontal position of the pixel clicked. 

Y - the vertical position of the pixel clicked.

GreenRed - The sum of Green plus Red.

BlueGreen - The sum of Blue plus Green.

BlueRed - The sum of Blue plus Red.

Alpha - The Transparency Level of the pixel. Values are 0 - 255, where 0 is transparent and 255 is visible.

You can use all of the above values in your queries to manipulate your image.

I have to run to Starbucks and walk my doc, docs will be finished today (Thanksgiving in the US).








