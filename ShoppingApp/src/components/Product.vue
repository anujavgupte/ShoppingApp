<template>
    <div id="product">
        <div>
            <h1>{{ Title }}</h1>
            <div class="product-image" style="float:left">
                <img :src="image" />
            </div>
            <div class="product-info" style="float:left">

                <p>Shipping :{{isShipping}}</p>
                <p v-if="inStock"> Instock</p>
                <p v-else>Out of stock</p>

                <ul>
                    <li v-for="detail in details">
                        {{ detail }}
                    </li>
                </ul>
                <div style='display:flex; width:80px;float:left' v-for="(variant,index) in variants">
                    <p :key="variant.id"
                       class="color-box"
                       :style="{backgroundColor: variant.color }"
                       @mouseover="ChangeProductImage(index)" />
                </div>
                <div style="display:block;" >
                    <button v-on:click="addToCart"
                            :disabled="!inStock"
                            :class="{disabledButton: !inStock}">
                        Add to cart
                    </button>
                </div>
            </div>
        </div>
        <div style="display:block; width:500px">
            <h2>Reviews</h2>
            <ProductTab :reviews="reviews" @review-submitted='submitReview'></ProductTab>
        </div>
    </div>
    

</template>

<script lang="ts">
    import { Component, Prop, Vue, Watch } from 'vue-property-decorator';
    import ProductReviewType from "./ProductReviewType";
    import ProductTab from "./ProductTab.vue";
    import ProductDetailType from "./ProductDetailType";
   
    @Component({
        components: {
            ProductTab
        }
    })


    export default class Product extends Vue {
        //Props
        @Prop({ required: false, default: true }) private premium!: boolean;
        @Prop({ required: false, default: true }) private variants!: ProductDetailType[];

        //Data
        brand = "Ferrari";
        product: string = 'Cars';
        selectedVariant: number = 0;
        images = [{ image: require('../assets/ferrari-blue.jpg') }, { image: require('../assets/ferrari-red.jpg') }, { image: require('../assets/ferrari-yellow.jpg') }];
        details = ["Engine -Petrol", "Power - 660:bph", "Doors -2Door"];
        image: string = "";
        inStock = 0;
        reviews: ProductReviewType[] = [];

         //Method 
        addToCart() {
            this.$emit('add-to-cart', this.variants[this.selectedVariant].id);
        }
       
        ChangeProductImage(index: any) {
            this.selectedVariant = index;
            
            this.image = this.images[this.selectedVariant].image;
            this.inStock = this.variants[this.selectedVariant].quantity;

            console.log(index);
        }

        submitReview(productReview: ProductReviewType) {
            this.reviews.push(productReview)
        }

        get Title() {
            return this.brand + " " + this.product
        }

        get isShipping() {
            if (this.premium == true) {
                return "Free";
            }
            else {
                return "2.95";
            }
        }
      //Watch
        @Watch("variants")
        setThevalue()
        {
            if (this.variants.length > 0) {
                this.image = this.images[this.selectedVariant].image;
                this.inStock = this.variants[this.selectedVariant].quantity;
            }
        }
    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>


