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



    //addKnownFolderId();
    addCreationCollision();
}());

function addKnownFolderId() {
    window.Windows.Storage.KnownFolderId = {
        0: "appCaptures",
        1: "cameraRoll",
        2: "documentsLibrary",
        3: "homeGroup",
        4: "mediaServerDevices",
        5: "musicLibrary",
        6: "objects3D",
        7: "picturesLibrary",
        8: "playlists",
        9: "recordedCalls",
        10: "removableDevices",
        11: "savedPictures",
        12: "screenshots",
        13: "videosLibrary",
        14: "allAppMods",
        15: "currentAppMods"
    };
}


function addCreationCollision() {
    window.Windows.Storage.CreationCollisionOption = {
        0: "GenerateUniqueName",
        1: "ReplaceExisting",
        2: "FailIfExists",
        3: "OpenIfExists"
    };
}

