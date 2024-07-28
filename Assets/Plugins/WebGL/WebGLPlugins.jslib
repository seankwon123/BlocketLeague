mergeInto(LibraryManager.library, {

  CreateAccountJS: function(nicknamePtr) {
     if (typeof window.createAccount === 'function') {
      window.createAccount(nickname).then(function(result) {
        console.log("Account created:", result);
        // You can send data back to Unity here if needed
      }).catch(function(error) {
        console.error("Error creating account:", error);
      });
    } else {
      console.error("createAccount function not found in the global scope");
    }
  },
});