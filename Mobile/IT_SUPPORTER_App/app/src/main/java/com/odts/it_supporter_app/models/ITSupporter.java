package com.odts.it_supporter_app.models;

import com.google.gson.annotations.SerializedName;

public class ITSupporter {
    @SerializedName("ITSupporterId")
    private Integer itSupporterId;
    @SerializedName("ITSupporterName")
    private String itSupporterName;
    @SerializedName("AccountId")
    private Integer accountId;
    @SerializedName("Telephone")
    private String telephone;
    @SerializedName("Email")
    private String email;
    @SerializedName("RatingAVG")
    private float ratingAVG;

    public float getRatingAVG() {
        return ratingAVG;
    }

    public void setRatingAVG(float ratingAVG) {
        this.ratingAVG = ratingAVG;
    }

    public Integer getItSupporterId() {
        return itSupporterId;
    }

    public void setItSupporterId(Integer itSupporterId) {
        this.itSupporterId = itSupporterId;
    }

    public String getItSupporterName() {
        return itSupporterName;
    }

    public void setItSupporterName(String itSupporterName) {
        this.itSupporterName = itSupporterName;
    }

    public Integer getAccountId() {
        return accountId;
    }

    public void setAccountId(Integer accountId) {
        this.accountId = accountId;
    }

    public String getTelephone() {
        return telephone;
    }

    public void setTelephone(String telephone) {
        this.telephone = telephone;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
}
