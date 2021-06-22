function notify(message) {
  let notificationElement = document.getElementById('notification');
  notificationElement.textContent = message;
  notificationElement.setAttribute('style', 'display:block');

  notificationElement.addEventListener('click', () => {
    notificationElement.setAttribute('style', 'display:none');
  });
}