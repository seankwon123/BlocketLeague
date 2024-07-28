mergeInto(LibraryManager.library, {
  CreateAccountJS: function(nicknamePtr) {
    var nickname = UTF8ToString(nicknamePtr);
    createAccount(nickname).then(function(result) {
      console.log("Account created:", result);
      // You can send data back to Unity here if needed
    }).catch(function(error) {
      console.error("Error creating account:", error);
    });
  },
});