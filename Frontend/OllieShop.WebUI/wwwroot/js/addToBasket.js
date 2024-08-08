
    document.addEventListener('DOMContentLoaded', function () {
        document.querySelectorAll('.add-to-basket').forEach(button => {
            button.addEventListener('click', async function (e) {
                e.preventDefault();
                const productId = this.getAttribute('data-product-id');
                document.getElementById('modalProductId').value = productId;

                try {
                    // Fetch product details
                    const response = await fetch(`/ProductList/GetProductWithAllDetails?id=${productId}`);
                    const product = await response.json();

                    // Check if product has sizes
                    if (!product.sizes || product.sizes.length === 0) {
                        // Redirect to product detail page
                        window.location.href = `/ProductList/ProductDetail/${productId}`;
                        return;
                    }

                    // Populate size options
                    const sizeSelect = document.getElementById('sizeSelect');
                    sizeSelect.innerHTML = ''; // Clear previous options
                    product.sizes.forEach(size => {
                        const option = document.createElement('option');
                        option.value = size.sizeId;
                        option.text = size.name;
                        sizeSelect.add(option);
                    });

                    // Add event listener to sizeSelect to fetch colors for selected size
                    sizeSelect.addEventListener('change', async function () {
                        const selectedSizeId = this.value;
                        const colorSelect = document.getElementById('colorSelect');
                        colorSelect.innerHTML = ''; // Clear previous options

                        if (selectedSizeId) {
                            try {
                                const colorResponse = await fetch(`/ProductList/GetColorsForSize?sizeId=${selectedSizeId}&productId=${productId}`);
                                const colors = await colorResponse.json();
                                colors.forEach(color => {
                                    const option = document.createElement('option');
                                    option.value = color.colorId;
                                    option.text = color.name;
                                    colorSelect.add(option);
                                });
                            } catch (error) {
                                console.error('Error fetching colors:', error);
                            }
                        }
                    });

                    // Trigger the size change event to populate colors for the default selected size
                    sizeSelect.dispatchEvent(new Event('change'));

                    // Show modal if product has sizes
                    $('#productModal').modal('show');

                } catch (error) {
                    console.error('Error fetching product details:', error);
                }
            });
        });
    });