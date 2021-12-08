<template>
    <div style="display:inline-block">
        <div>
            <span :class="{ activeTab: selectedTab === tab }"
                  v-for="(tab, index) in tabs"
                  @click="selectedTab = tab"
                  :key="tab" style='display:block;width:150px;float:left'>{{ tab }}</span>
        </div>

        <div v-show="selectedTab === 'Reviews'">
            <p v-if="!reviews.length">There are no reviews yet.</p>
            <ul v-else>
                <li v-for="(review, index) in reviews" :key="index">
                    <p>Name: {{ review.name }}</p>
                    <p>Rating: {{ review.rating }}</p>
                    <p>Review: {{ review.review }}</p>
                </li>
            </ul>
        </div>

        <div v-show="selectedTab === 'Make a Review'">
            <ProductReview @review-submitted='submitReview'></ProductReview>
        </div>

    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue, Watch } from 'vue-property-decorator';
    import ProductReview from './ProductReview.vue';
    import ProductReviewType from "./ProductReviewType";
    @Component({
        components: {
            ProductReview
        }
    })

    export default class ProductTab extends Vue {
        //Prop
        @Prop({ required: false, type: Array }) private reviews!: boolean;
        //Data
        tabs = ['Reviews', 'Make a Review'];
        selectedTab = 'Reviews';
        //Method
        submitReview(productReview: ProductReviewType) {
            this.$emit('review-submitted', productReview);
        }
    }
</script>

<style scoped>
 
</style>