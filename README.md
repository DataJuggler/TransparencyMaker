# TransparencyMaker
Transparency Maker reads in a .jpg or .png and creates a Pixel Information Database, that can be manipulated in a language I invented called BQL or Bitmap Query language.

# Motivation
The reason I wrote this program originally is when I purchase stock photos, almost all come with a background color and often I need a transparent background. There are other tools that perform background removal, with more now than in 2012 when I started working on Transparency Maker, however I wanted a way to programmaticaly manipulate pixels.

# Rebranding the name to Pixel Database
The original purpose of Transparency Maker was to make backgrounds transparent, thus the name. I have now expanded the features to include features for updating pixels, changing colors, drawing lines, etc. 

What do you think? Should I keep the name Transparency Maker, or do you like Pixel Database better? 

Let me know by creatiing an Issue on this project, or on any Transparency Maker videos on YouTube.

# Transparency Maker Videos on my Channel

https://www.youtube.com/playlist?list=PLKrW5tXCPiX2PxrLPszDzlcEZwQG-Qb8r

I just updated my channel to be split into more play lists to separate each section.

# How Transparency Maker Works
The first thing that happens when an image is opened, is your file is parsed into a Pixel Information Database, aka Pixel Database.

When the program starts, click the Start button to select your image. The image must be a Png or a Jpg.

<img src="https://github.com/DataJuggler/TransparencyMaker/blob/master/Docs/ScreenShot.png">

A Pixel Database is a List of PixelInformation objects that contain properties about the pixel. To find the pixel information for any pixel, turn the Color Picker on.

<img src="https://github.com/DataJuggler/TransparencyMaker/blob/master/Docs/ColorPicker.png">

Tip: To determiine if the Color Picker is on, hover your mouse of any part of your image. If the mouse cursor turns into a pointer (a hand), then the Color Picker is on. 

Once the Color Picker is turned on, click any pixel in your image and a Pixel Information Box pops up:

<img src="https://github.com/DataJuggler/TransparencyMaker/blob/master/Docs/PixelInfoBox.png">

The box contains the following properties:

# Red
The Red value of RGB value. Value range is 0 - 255.

# Green
The Green value of RGB value. Value range is 0 - 255.

# Blue
The Blue value of RGB value. Value range is 0 - 255.

# Alpha
The Transparency Level of the pixel. Values are 0 - 255, where 0 is transparent and 255 is visible.

# X
The horizontal position of the pixel clicked. 

# GreenRed
The sum of Green plus Red.

# BlueGreen
The sum of Blue plus Green.

# BlueRed
The sum of Blue plus Red.

# Total
The sum of Red plus Green plus Blue.

# Y
The vertical position of the pixel clicked.

You can use all of the above values in your queries to manipulate your image.

# BQL - Bitmap Query Language

# Why BQL?
This application started out as a plain Windows Form that I would hard code C# statements to replace the background of stock photos with transparent backgrounds. Over time I switched to a more object oriented approach where I analyze the entire image, and thus the Pixel Database was created.

The initial criticism I have received is there are not any controls like most graphic programs. If that is what everyone still wants I am open to ideas about what types of controls are needed. I created BQL because it is similar to SQL that many C# developers already know, thus enabling them to get up to speed quickly. Another reason I created BQL instead of a control based graphical UI is time to develop. Many of my failed endeavors have involved very complicated UI's, and then I am reminded of this small company called Google that started with a webpage that contained a single textbox and a button. 

# Hide / Show vs Update Queries

There are two types of queries:

# Hide / Show

# Hide
Any pixels affected by the query will be set to Alpha 0, which makes them invisible.

# Example
Hide Pixels Where  
Total > 700

# Shortcut for Hide Pixels is Hide, so the same example can be rewritten

Hide
Total > 700 

# Show
Any pixels affected by the query will be set to Alpha 255, which makes them visible.

# Example
Show Pixels Where  
Red < 200

# Shortcut for Hide Pixels is Show, so the above example can be rewritten

Show
Red < 200

# Important
This query parser may be rewritten to be more robust someday, but for now certain attributes must be on their own line.
I wrote the query parser in a few hours many years ago, and it works pretty well so I have not bothered to refactor it (yet).

So the query above would fail if written like this

# Invalid
Show X < 150

# Correct
Show
X < 150

It wouldn't be that hard to rewrite the query parser, so let me know if you think the line by line requirement is confusing. I know it is crude, but this app was designed to be quick, dirty and functional at first.

# Operators

# Equals
# Equals Symbol: =
Will match criteria on exact values.

# Equal Example: 

Hide
Red = 233

All pixels that have a Red value of 233 will be set to Alpha 0 to be hidden.

# Greater Than
# Greater Than Symbol: >

Will match criterian on greater than or equal to

# Greater Than Example

Show
Y > 1200

All pixels with a Y value of 1,200 or higher wil be set to Alpha 255 to be shown.

# Less Than
# Less Than Symbol: <

Will match criterian on less than or equal to

# Less Than Example

Hide
BlueGreen < 300

All pixels with a BlueGreen value of 300 or less wil be set to Alpha o to be hidden.

# Between

Will match criteria that is greater than or equal to the first number and less than or equal to the second number.

# Between Example

Hide
Blue Between 200 255

All pixels with a Blue value between 200 and 255 will be hidden.


# Compound Statements

You can combine criteria to further narrow down the pixels that are manipulated

# Important: Each criteria must be on its own line.

# Coupound Examples:

Show
X > 200
Y Between 112 140
Total = 765

All pixels with X coordinate of 200 or higher and a Y value of 112 - 140 and a Total of 765 (White).

# Update Queries
Update queries are very similar to Hide queries, except that you must include a Color attribute

# Set Color
There are two ways to set a color, Named Colors or RGB values.

# Named Color
You can set a pixel to a named color

Note: For a list of Dot Net Colors see System.Drawing.Colors or this website lists them:
http://www.flounder.com/csharp_color_table.htm 

# Named Color Example

Update
Set Color FireRed
Where
Total Between 125 150

# Note: Where must be on its own line for Update queries

# RGB Color
You set the color by specifying the Red, Green and Blue values

# RGB Color Example

Update
Set Color 121 220 7
Where
Y > 100

# Where is not optional

You must specify the Where, even if you want to update all pixels

Update 
Set Color White
Where
Total > 0

# Note: In the above example, all pixels will be set to white, since greater than > is equal to > or equal to.

# Normalizing An Image
One of the uses of Transparency Maker is take an image that is grainy or pixelated, you can smooth out an area by
setting all pixels in a range to a certain value.

Update
Set Color 220 0 55
Where
Color Total Between 525 590
X Between 200 360
Y > 400

# Drawing Lines
You can draw lines to hide pixels along a line, or you can draw lines of a specific color.






















