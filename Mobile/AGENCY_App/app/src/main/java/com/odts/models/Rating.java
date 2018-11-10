package com.odts.models;

import com.google.gson.annotations.SerializedName;

public class Rating {
    @SerializedName("RequestId")
    private Integer requestId;
    @SerializedName("Rating")
    private Integer ratring;
    @SerializedName("Description")
    private String description;

    public Rating() {
    }

    public Rating(Integer requestId, Integer ratring, String description) {
        this.requestId = requestId;
        this.ratring = ratring;
        this.description = description;
    }

    public Integer getRequestId() {
        return requestId;
    }

    public void setRequestId(Integer requestId) {
        this.requestId = requestId;
    }

    public Integer getRatring() {
        return ratring;
    }

    public void setRatring(Integer ratring) {
        this.ratring = ratring;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }
}
