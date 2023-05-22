const userDeleteBtns = document.querySelectorAll('#user-delete-btn');

userDeleteBtns.forEach((button) => {
    button.addEventListener('click', () => {
        const userId = button.getAttribute('data-user-id');

        const confirmDelete = confirm("Are you sure you want to delete this user?")

        if (confirmDelete) {
            fetch('/Admin/DeleteUser/' + userId, {
                method: 'POST'
            })
                .then((response) => {
                    if (response.ok) {
                        console.log("User was deleted");
                        const listItem = button.closest('.list-item-user');
                        listItem.remove();
                    }
                    else {
                        console.log("Error deleting user");
                    }
                })
                .catch((error) => {
                    console.log("Error deleting user");
                })
        }
    })
})

const productDeleteBtns = document.querySelectorAll('#product-delete-button');

productDeleteBtns.forEach((button) => {
    button.addEventListener('click', () => {
        const productId = button.getAttribute('data-product-id');

        const confirmDelete = confirm("Are you sure you want to delete this Product?")

        if (confirmDelete) {
            fetch('/Admin/DeleteProduct/' + productId, {
                method: 'POST'
            })
                .then((response) => {
                    if (response.ok) {
                        console.log("Product was deleted");
                        const listItem = button.closest('.list-item-product');
                        listItem.remove();
                    }
                    else {
                        console.log("Error removing product");
                    }
                })
                .catch((error) => {
                    console.log("Error deleteing product")
                })
        }
    })
})

const validateEmail = (event) => {
    const regEx = /[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?/
    if (regEx.test(event.target.value)) {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
    }
    else {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Enter a valid email"
    }
};

const validateText = (event) => {
    if (event.target.value.length >= 2) {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
    }
    else {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Must be atleast 2 characters long"
    }
};

const validatePassword = (event) => {
    const regEx = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/

    if (regEx.test(event.target.value)) {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = ""
    }
    else {
        document.querySelector(`[data-valmsg-for="${event.target.id}"]`).innerHTML = "Your password must be atleast 8 characters, must contain atleast one uppercase letter, one lowercase letter and one special character"
    }
};

                  