<template>
    <div id="app">
        <div class="nav-bar">
            <div class="cart">
                <p>Cart({{cart}})</p>
            </div>
        </div>
        <Product :premium="premium" @add-to-cart='updateCart'  :variants="variants"></Product>

    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import Product from './components/Product.vue';
    import ProductDetailType from "./components/ProductDetailType";
  
    import axios, { AxiosResponse } from 'axios'
    import VueAxios from 'vue-axios'
    Vue.use(VueAxios, axios)

    @Component({
        components: {
            Product
        }
    })
    export default class App extends Vue {
        //Data
        premium: boolean = true;
        cart: number[] = [];
        variants : ProductDetailType[] =[];

        //Methods
        mounted() {
             this.makeGetRequest();
        }

        async  makeGetRequest() {
            let res = await axios.get('https://localhost:44329/Shopping');
            let data = res.data;
            this.variants = res.data;
            console.log(data);
        }

        updateCart(id: number) {
            return this.cart.push(id);
        }
       
    }
</script>
<style>
    /*CssFile Added*/
    @import url('../public/Styles/Shopping.css');
</style>

