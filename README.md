# UWP Windows Multi-Instancing Background Task Issue Example
This project showcases an issue with Windows UWP Multi-Instancing projects not running Out of Proccess Background Tasks.
The documentation states that Multi-Instancing should support Out of Process Background Tasks.

This project is a simple UWP project with an Out of Process Background Task in a Windows Component Project.
The Button should Run the Background Task and allow debugging of the code.

When Multi-Instancing is enabled, the background task does not run, and the code does not execute.

When Multi-Instancing is disabled, the background task runs and allows debugging of the code.

To enable/disable Multi-Instancing: 

In the Package.appxmanifest file -> Right Click -> View Code, desktop104:SupportsMultipleInstances="true" is set to "true" to enable Multi-Instancing by default

To disable Multi-Instancing, set desktop104:SupportsMultipleInstances="false"

When Multi-Instancing is disabled, the background task runs as expected.

