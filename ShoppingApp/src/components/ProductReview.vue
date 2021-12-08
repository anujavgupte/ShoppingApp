<template>
    <form class="review-form" @submit.prevent="onSubmit">

        <p>
            <label for="name">Name:</label>
            <input id="name" v-model="name">
        </p>

        <p>
            <label for="review">Review:</label>
            <textarea id="review" v-model="review"></textarea>
        </p>

        <p>
            <label for="rating">Rating:</label>
            <select id="rating" v-model.number="rating">
                <option>5</option>
                <option>4</option>
                <option>3</option>
                <option>2</option>
                <option>1</option>
            </select>
        </p>

        <p>
            <input type="submit" value="Submit">
        </p>

    </form>
</template>

<script lang="ts">
    import { Component, Prop, Vue, Watch } from 'vue-property-decorator';
    import ProductReviewType from "./ProductReviewType";

    export default class ProductReview extends Vue {

        //Data
        productReviewdata = new ProductReviewType;
        name: string = "";
        review: string = "";
        rating: number | null = 0;
        errors: string[] = [];
        //Methods
        onSubmit(e: any) {
            if (this.name && this.review && this.rating) {

                this.productReviewdata = {
                    name: this.name,
                    review: this.review,
                    rating: this.rating
                }

                this.name = " ";
                this.review = "";
                this.rating = null;
                this.$emit('review-submitted', this.productReviewdata);

            } 
            e.preventDefault();
        }
    }

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>