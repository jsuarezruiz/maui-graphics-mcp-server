# .NET MAUI Graphics MCP Server

**Effortlessly craft stunning mobile UI components with AI, powered by the Model Context Protocol!** 🚀

This Model Context Protocol (MCP) is designed for building .NET MAUI controls, offering powerful utilities for drawing everything from basic shapes and text to intricate paths. By seamlessly combining these elements, developers can craft visually stunning UI components with precision and flexibility.

![.NET MAUI Graphics MCP Server](images/maui-graphics-mcp.gif)

You can see what's being created in real time, and also have access to all the generated code!

### Setup
1. Clone this repository
2. Navigate to the project directory
3. Build the project: `dotnet build`
4. Configure with VS Code or other client:

```json
"mcp-server-maui-graphics": {
    "type": "stdio",
    "command": "dotnet",
    "args": [
        "run",
        "--project",
        "/Users/jsuarezruiz/GitHub/maui-graphics-mcp-server/src/MauiGraphicsMcp.csproj"
    ]
}
```

### Testing

The MCP Inspector is an interactive developer tool designed for testing and debugging MCP servers. Can start the inspector from our application folder using the nodejs command npx with the following command:

`npx @modelcontextprotocol/inspector dotnet run`

### Tools

* `maui_graphics_clear` – Clears the entire drawing canvas, resetting it to a blank state.
* `maui_graphics_fill_circle` – Draws a solid filled circle at a specified location with a given radius.
* `maui_graphics_draw_circle` – Draws the outline of a circle without filling the interior.
* `maui_graphics_fill_rectangle` – Creates a solid filled rectangle at a defined position with width and height.
* `maui_graphics_draw_rectangle` – Draws the border of a rectangle without filling the inside.
* `maui_graphics_fill_rounded_rectangle` – Generates a rectangle with rounded corners and fills it with a solid color.
* `maui_graphics_draw_rounded_rectangle` – Draws the outline of a rounded rectangle without filling.
* `maui_graphics_draw_line` – Creates a straight line between two points.
* `maui_graphics_fill_path` – Fills a custom path shape with solid color or gradient.
* `maui_graphics_draw_path` – Draws the outline of a custom path shape.
* `maui_graphics_draw_text` – Renders text onto the canvas at a given position.

### Example AI Assistant Queries

Try these queries:

* _"Generate two visually distinct ToggleSwitch components representing the 'On' and 'Off' states for a mobile UI. The design should be clean, modern, and user-friendly."_
* _"Create a dynamic bar chart with labeled axes, color-coded bars, and gridlines for easy readability."_
* _"Create a horizontal slider for adjusting volume, brightness, or other settings."_
* _"Create a numeric input field with plus and minus buttons to increase or decrease values."_

### Gallery

<img src="images/chart.png" width="40%"></img> <img src="images/toggleswitch.png" width="40%"></img> <img src="images/numericupdown.png" width="40%"></img> <img src="images/slider.png" width="40%"></img>

### Contributing

I gladly welcome contributions to help improve this project! Whether you're fixing bugs, adding new features, or enhancing documentation, your support is greatly appreciated.

1. Fork the repository
2. Create your feature branch (git checkout -b feature/my-feature)
3. Make your changes
4. Commit your changes (git commit -m 'Add a new feature')
5. Push to the branch (git push origin feature/my-feature)
6. Open a Pull Request

### License

This project is available under the MIT License.
