import firebase from'firebase/app';
import 'firebase/auth';

const firebaseConfig = {
    apiKey: "AIzaSyDpZg-DLK7PWy2TqiW3dx8j9ZQiW_bA71k",
    authDomain: "authreact-cc098.firebaseapp.com",
    projectId: "authreact-cc098",
    storageBucket: "authreact-cc098.appspot.com",
    messagingSenderId: "279523572841",
    appId: "1:279523572841:web:edf82d99d4916bf1ab36f8"
  };

//   if (!firebase.app.length) {
// }
firebase.initializeApp(firebaseConfig);      



export default firebase;

export const auth = firebase.auth();
