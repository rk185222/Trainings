var blazorInterop = blazorInterop || {};

blazorInterop.showAlert = function (message) {
  alert(message);
};

blazorInterop.logToConsoleTable = function (obj) {
  console.table(obj);
};

blazorInterop.showPrompt = function (message, defaultValue) {
  return prompt(message, defaultValue);
};

blazorInterop.createEmployee = function (firstName, lastName) {
  return { firstName, lastName, email: firstName + "@thomasclaudiushuber.com" };
};

blazorInterop.focusElement = function (element) {
  element.focus();
};

blazorInterop.focusElementById = function (id) {
  var element = document.getElementById(id);
  if (element) element.focus();
};

blazorInterop.throwsError = function () {
  throw Error("Thomas didn't implement this function");
};

blazorInterop.callStaticDotNetMethod = function () {
  var promise = DotNet.invokeMethodAsync("BethanysPieShopHRM.ServerApp",
    "BuildEmail", "Thomas");
  promise.then(email => alert(email));
};

blazorInterop.callStaticDotNetMethodCustomIdentifier = function () {
  var promise = DotNet.invokeMethodAsync("BethanysPieShopHRM.ServerApp",
    "BuildEmailWithLastName", "Thomas","Huber");
  promise.then(email => alert(email));
};

blazorInterop.callDotNetInstanceMethod = function (dotNetObjectRef) {
  dotNetObjectRef.invokeMethodAsync("SetWindowSize",
    {
      width: window.innerWidth,
      height: window.innerHeight
    });
};

blazorInterop.registerResizeHandler = function (dotNetObjectRef) {
  function resizeHandler() {
    dotNetObjectRef.invokeMethodAsync("SetWindowSize",
      {
        width: window.innerWidth,
        height: window.innerHeight
      });
  };

  // Set up initial values
  resizeHandler();

  // Register event handler
  window.addEventListener("resize", resizeHandler);
};