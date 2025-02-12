# MyMandelbrotExplorer

An interactive C# application to explore Mandelbrot and Julia Sets.

## Features
- Navigate in the sets using mouse (drag and zoom)
- Choose custom amount of iterations for the formula used to render the sets
- Choose and create custom gradient colormaps
- Capture screenshots
- Create zooming videos on a specific location
- Render Julia Set with custom X and Y parameters

## Performance
The rendering of the sets is a tough task in terms of operations to do. I tried my best to optimise the code and i also used multithreading. \
I managed to render the full 1500x1000 starting image in 0.028s (on my PC).

# Limitations
- The canvas (image) size is fixed at 1500x1000 pixels
- The zoom factor is limited by the double number precision, so below a zoom factor of 3E-12, you risk underflow issues and the image glitches

## Screenshots
Here are some screenshots I got while exploring the Mandelbrot Set:
<table>
  <tr>
    <td><img src="Screenshots/shot1.png"></td>
    <td><img src="Screenshots/shot2.png"></td>
  </tr>
  <tr>
    <td><img src="Screenshots/shot3.png"></td>
    <td><img src="Screenshots/shot4.png"></td>
  </tr>
  <tr>
    <td><img src="Screenshots/shot5.png"></td>
    <td><img src="Screenshots/shot6.png"></td>
  </tr>
</table>










