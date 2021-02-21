var plugin = {
    GetInput : function(){
        return window.GAME_CAVE_GET_USER_INPUT();
    }
};

mergeInto(LibraryManager.Library, plugin);