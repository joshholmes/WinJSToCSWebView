//function createFile() {
//    Windows.Storage.KnownFolders.getFolderForUserAsync(null /* current user */, Windows.Storage.KnownFolderId.picturesLibrary).then(function (picturesLibrary) {
//        return picturesLibrary.createFileAsync("sample.dat", Windows.Storage.CreationCollisionOption.replaceExisting);
//    }).done(
//        function (file) {
//            SdkSample.sampleFile = file;
//            WinJS.log && WinJS.log("The file '" + SdkSample.sampleFile.name + "' was created.", "sample", "status");
//        },
//        function (error) {
//            WinJS.log && WinJS.log(error, "sample", "error");
//        });
//}
(function () {
    function isObject(value) {
        return typeof value === "object" &&
            value !== null;
    }

    function capitalize(string) {
        return string.charAt(0).toUpperCase() + string.slice(1);
    }

    function fixNamespace(object) {
        if (!isObject(object)) {
            return object;
        }

        const result = {};

        for (let key in object) {
            let value = object[key];

            if (isObject(value)) {
                key = capitalize(key);
            }

            value = fixNamespace(value);

            result[key] = typeof value === "function"
                ? value.bind(object)
                : value;
        }

        return result;

    }

    window.Windows = fixNamespace(WindowsPolyFill);

    //WinJS.Namespace.define("Windows.Storage.Streams", {
    //    InMemoryInMemoryRandomAccessStream: window.Windows.Storage.Streams.InMemoryInMemoryRandomAccessStream;
    //});
}());
