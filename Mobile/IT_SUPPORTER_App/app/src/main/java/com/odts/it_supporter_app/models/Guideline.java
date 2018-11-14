package com.odts.it_supporter_app.models;

import com.google.gson.annotations.SerializedName;

public class Guideline {
    @SerializedName("GuidelineId")
    private Integer guidelineId;
    @SerializedName("ServiceItemId")
    private Integer serviceItemId;
    @SerializedName("GuidelineName")
    private String guidelineName;

    public Integer getGuidelineId() {
        return guidelineId;
    }

    public void setGuidelineId(Integer guidelineId) {
        this.guidelineId = guidelineId;
    }

    public Integer getServiceItemId() {
        return serviceItemId;
    }

    public void setServiceItemId(Integer serviceItemId) {
        this.serviceItemId = serviceItemId;
    }

    public String getGuidelineName() {
        return guidelineName;
    }

    public void setGuidelineName(String guidelineName) {
        this.guidelineName = guidelineName;
    }
}
