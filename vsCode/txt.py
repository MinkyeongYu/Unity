import pandas as pd
import numpy as np
from sklearn.feature_extraction.text import CountVectorizer
from sklearn.naive_bayes import MultinomialNB
from sklearn.naive_bayes import BernoulliNB
from sklearn.metrics import accuracy_score
from sklearn.model_selection import train_test_split
# from sklearn.externals import joblib
import sys
sys.path.append('./opt/anaconda3/lib/python3.9/site-packages (1.1.0)')
import joblib
import os
import shutil

news_data0 = pd.read_csv("newTrainNeg.csv", header=0)
news_data1 = pd.read_csv("newCasteViol.csv", header=0)
news_data2 = pd.read_csv("newNCdata.csv", header=0)
news_data3 = pd.read_csv("Water.csv", header=0)
news_data4 = pd.read_csv("Religious.csv", header=0)
news_data5 = pd.read_csv("CasteDiscriArticles.csv", header=0)
news_data6 = pd.read_csv("Land.csv", header=0)
news_data7 = pd.read_csv("Wedding.csv", header=0)
news_data8 = pd.read_csv("Daily.csv", header=0)
# news = list(news_data0) + list(news_data1)
label = []
news_data0 = list(news_data0)
news_data1 = list(news_data1)
news_data2 = list(news_data2)
news_data3 = list(news_data3)
news_data4 = list(news_data4)
news_data5 = list(news_data5)
news_data6 = list(news_data6)
news_data7 = list(news_data7)
news_data8 = list(news_data8)

news_data5 = list(news_data5)
print(len(news_data0), len(news_data1), len(news_data2), len(news_data5))
news = news_data0 + news_data1 + news_data2 + news_data3 + news_data4 + news_data5 + news_data6 + news_data7 + news_data8

for i in range(len(news_data0)):
    label.append(0)
for i in range(len(news_data1)):
    label.append(1)
for i in range(len(news_data2)):
    label.append(1)
for i in range(len(news_data3)):
    label.append(1)
for i in range(len(news_data4)):
    label.append(1)
for i in range(len(news_data5)):
    label.append(1)
for i in range(len(news_data6)):
    label.append(1)
for i in range(len(news_data7)):
    label.append(1)
for i in range(len(news_data8)):
    label.append(1)

data = [news, label]

vectorizer = CountVectorizer()
text_data = vectorizer.fit_transform(news)

# Split the data into training and testing sets
print(text_data.shape)
label = np.transpose(label)
print(label.shape)
X_train, X_test, y_train, y_test = train_test_split(text_data, label, test_size=0.2, random_state=42, shuffle=True)
# Train the model
model = MultinomialNB()
model.fit(X_train, y_train)
# Predict on the testing data
y_pred = model.predict(X_test)
# Calculate the accuracy
accuracy = accuracy_score(y_test, y_pred)
print("Accuracy:", accuracy)
# Train the model
model = MultinomialNB()
model.fit(text_data, label)
# Save the model for later use
joblib.dump(model, "text_classification_model.pkl")
#
# Load the model (if already trained)
model = joblib.load("text_classification_model.pkl")
unlabel = list(pd.read_csv("Hindus2010-2013.csv", header=0))
title = list(pd.read_csv("Hindus2010-2013title.csv", header=0))

# Prepare the new, unlabelled data
vectorizer = CountVectorizer()
vectorizer.fit(news)
new_text_data = vectorizer.transform(unlabel)

# Predict the labels for the new data
predicted_labels = model.predict(new_text_data)

rel = []
rel_con = []
date = []
loc = []
rel_date = []
rel_loc = []
rel_tex = []
import csv

data = pd.read_csv('/Users/sallybun/Downloads/TheHindu_WebArchive_Article-TEXT_2010-2013.csv', header=0, lineterminator='\n')
dateline = list(data["dateline"])
tex = list(data["text"])

for i in dateline:
    if " - " in i:
        date.append(i.split(" - ")[0])
        loc.append(i.split(" - ")[1])
    else:
        date.append(None)
        loc.append(None)

for i in range(len(predicted_labels)):
    if predicted_labels[i] == 1:
        rel.append(title[i])
        rel_con.append(unlabel[i])
        rel_loc.append(loc[i])
        rel_date.append(loc[i])
        rel_tex.append(tex[i])


news_data0 = pd.read_csv("CasteViol4Label.csv", header=0)
news_data1 = pd.read_csv("PolViol4Label.csv", header=0)
news_data2 = pd.read_csv("RelViol4Label.csv", header=0)
news_data3 = pd.read_csv("ViolOther4Label.csv", header=0)
news_data4 = pd.read_csv("CasteDiscriArticles.csv", header=0)
news_data5 = pd.read_csv("Water.csv", header=0)
news_data6 = pd.read_csv("Land.csv", header=0)
news_data7 = pd.read_csv("Religious.csv", header=0)
news_data8 = pd.read_csv("Wedding.csv", header=0)
news_data9 = pd.read_csv("Daily.csv", header=0)

label = []
news_data0 = list(news_data0)
news_data1 = list(news_data1)
news_data2 = list(news_data2)
news_data3 = list(news_data3)
news_data4 = list(news_data4)
news_data5 = list(news_data5)
news_data6 = list(news_data6)
news_data7 = list(news_data7)
news_data8 = list(news_data8)
news_data9 = list(news_data9)

print(len(news_data0), len(news_data1), len(news_data2), len(news_data3))
news = news_data0 + news_data1 + news_data2 + news_data3 + news_data4 + news_data5 + news_data6 + news_data7 + news_data8 + news_data9

for i in range(len(news_data0)):
    label.append(0)
for i in range(len(news_data1)):
    label.append(1)
for i in range(len(news_data2)):
    label.append(1)
for i in range(len(news_data3)):
    label.append(2)
for i in range(len(news_data4)):
    label.append(1)
for i in range(len(news_data5)):
    label.append(1)
for i in range(len(news_data6)):
    label.append(1)
for i in range(len(news_data7)):
    label.append(1)
for i in range(len(news_data8)):
    label.append(1)
for i in range(len(news_data9)):
    label.append(1)
data = [news, label]

vectorizer = CountVectorizer()
text_data = vectorizer.fit_transform(news)

# Split the data into training and testing sets
print(text_data.shape)
label = np.transpose(label)
print(label.shape)
X_train, X_test, y_train, y_test = train_test_split(text_data, label, test_size=0.2, random_state=42, shuffle=True)
# Train the model
model = BernoulliNB()
model.fit(X_train, y_train)
# Predict on the testing data
y_pred = model.predict(X_test)
# Calculate the accuracy
accuracy = accuracy_score(y_test, y_pred)
print("Accuracy:", accuracy)
# Train the model
model = BernoulliNB()
model.fit(text_data, label)
# Save the model for later use
joblib.dump(model, "NB4label.pkl")
#
# Load the model (if already trained)
model = joblib.load("NB4label.pkl")
unlabel = rel_con
title = rel

# Prepare the new, unlabelled data
vectorizer = CountVectorizer()
vectorizer.fit(news)
new_text_data = vectorizer.transform(unlabel)

# Predict the labels for the new data
predicted_labels = model.predict(new_text_data)

path = "/Users/sallybun/Desktop"
os.chdir(path)
caste = []
dis = []
other = []
caste_con = []
dis_con = []
other_con = []
caste_tex = []
caste_loc = []
caste_date = []
dis_tex = []
dis_loc = []
dis_date = []
other_tex = []
other_loc = []
other_date = []

for i in range(len(predicted_labels)):
    if predicted_labels[i] == 0:
        caste.append(title[i])
        caste_con.append(unlabel[i])
        caste_date.append(rel_date[i])
        caste_loc.append(rel_loc[i])
        caste_tex.append(rel_tex[i])

    if predicted_labels[i] == 1:
        dis.append(title[i])
        dis_con.append(unlabel[i])
        dis_date.append(rel_date[i])
        dis_loc.append(rel_loc[i])
        dis_tex.append(rel_tex[i])

    else:
        other.append(title[i])
        other_con.append(unlabel[i])
        other_date.append(rel_date[i])
        other_loc.append(rel_loc[i])
        other_tex.append(rel_tex[i])

c_mur = []
cmur_tex = []
cmur_loc = []
cmur_date = []
c_kid = []
ckid_tex = []
ckid_loc = []
ckid_date = []
c_rap = []
crap_tex = []
crap_loc = []
crap_date = []
c_hon = []
chon_tex = []
chon_loc = []
chon_date = []
c_pol = []
cpol_tex = []
cpol_loc = []
cpol_date = []
c_ass = []
cass_tex = []
cass_loc = []
cass_date = []
c_oth = []
coth_tex = []
coth_loc = []
coth_date = []

o_mur = []
omur_tex = []
omur_loc = []
omur_date = []
o_kid = []
okid_tex = []
okid_loc = []
okid_date = []
o_rap = []
orap_tex = []
orap_loc = []
orap_date = []
o_hon = []
ohon_tex = []
ohon_loc = []
ohon_date = []
o_pol = []
opol_tex = []
opol_loc = []
opol_date = []
o_ass = []
oass_tex = []
oass_loc = []
oass_date = []
o_oth = []
ooth_tex = []
ooth_loc = []
ooth_date = []

d_wat = []
dwat_tex = []
dwat_loc = []
dwat_date = []
d_lan = []
dlan_tex = []
dlan_loc = []
dlan_date = []
d_wed = []
dwed_tex = []
dwed_loc = []
dwed_date = []
d_rel = []
drel_tex = []
drel_loc = []
drel_date = []
d_dai = []
ddai_tex = []
ddai_loc = []
ddai_date = []

nother = []
nother_tex = []
nother_loc = []
nother_date = []

for i in range(len(other)):
    if other[i] not in caste:
        nother.append(other[i])
        nother_loc.append(other_loc[i])
        nother_tex.append(other_tex[i])
        nother_date.append(other_date[i])

m = ["murder", "kill", "set ablaze", "set on fire", "to death", "death", "hung", "hang", "lynch", "die", "dead", "body", "bodies"]
nnother = []
nnother_date = []
nnother_loc = []
nnother_tex = []
for i in range(len(nother)):
    for j in m:
        if j in nother[i] and "honour" not in nother[i]:
            o_mur.append(nother[i])
            omur_loc.append(nother_loc[i])
            omur_tex.append(nother_tex[i])
            omur_date.append(nother_date[i])
        else: 
            nnother.append(nother[i])
            nnother_tex.append(nother_tex[i])
            nnother_loc.append(nother_loc[i])
            nnother_date.append(nother_date[i])

nnn = []
nnn_loc = []
nnn_tex = []
nnn_date = []
m = ["kidnap", "abduct", "missing"]
for i in range(len(nnother)):
    for j in m:
        if j in nnother[i]:
            o_kid.append(nnother[i])
            okid_loc.append(nnother_loc[i])
            okid_tex.append(nnother_tex[i])
            okid_date.append(nnother_date[i])
        else: 
            nnn.append(nnother[i])
            nnn_loc.append(nnother_loc[i])
            nnn_tex.append(nnother_tex[i])
            nnn_date.append(nnother_date[i])
            
nnnn = []
nnnn_loc = []
nnnn_tex = []
nnnn_date = []
m = ["rape", "gang-rape", "sexually harrass", "harrass"]
for i in range(len(nnn)):
    for j in m:
        if j in nnn[i]:
            o_rap.append(nnn[i])
            orap_loc.append(nnn_loc[i])
            orap_tex.append(nnn_tex[i])
            orap_date.append(nnn_date[i])
        else: 
            nnnn.append(nnn[i])
            nnnn_loc.append(nnn_loc[i])
            nnnn_tex.append(nnn_tex[i])
            nnnn_date.append(nnn_date[i])

s = []
s_loc = []
s_tex = []
s_date = []
m = ["honor", "honor killing", "honor-killing", "honour", "honour killing", "honour-killing", "honour kill", "honour-kill"]
for i in range(len(nnnn)):
    for j in m:
        if j in nnnn[i]:
            o_hon.append(nnnn[i])
            ohon_loc.append(nnnn_loc[i])
            ohon_tex.append(nnnn_tex[i])
            ohon_date.append(nnnn_date[i])
        else: 
            s.append(nnnn[i])
            s_loc.append(nnnn_loc[i])
            s_tex.append(nnnn_tex[i])
            s_date.append(nnnn_date[i])
            
ss = []
ss_loc = []
ss_tex = []
ss_date = []
m = ["assault", "abuse", "attack", "beat up", "beaten", "thrash", "thrown", "threw", "pelt", "stone", "hit", "punch", "forced to ", "choke"]
for i in range(len(s)):
    for j in m:
        if j in s[i]:
            o_ass.append(s[i])
            oass_loc.append(s_loc[i])
            oass_tex.append(s_tex[i])
            oass_date.append(s_date[i])
        else: 
            ss.append(s[i])
            ss_loc.append(s_loc[i])
            ss_tex.append(s_tex[i])
            ss_date.append(s_date[i])

m = ["protest", "boycott", "march", "campaign", "demand", "protestor"]
for i in range(len(ss)):
    for j in m:
        if j in ss[i]:
            o_pol.append(ss[i])
            opol_loc.append(ss_loc[i])
            opol_tex.append(ss_tex[i])
            opol_date.append(ss_date[i])
        else: 
            o_oth.append(ss[i])
            ooth_loc.append(ss_loc[i])
            ooth_tex.append(ss_tex[i])
            ooth_date.append(ss_date[i])

m = ["murder", "kill", "set ablaze", "set on fire", "to death", "death", "hung", "hang", "lynch", "die", "dead", "body",
     "bodies"]
nnother = []
nnother_date = []
nnother_loc = []
nnother_tex = []
for i in range(len(caste)):
    for j in m:
        if j in caste[i] and "honour" not in caste[i]:
            c_mur.append(caste[i])
            cmur_loc.append(caste_loc[i])
            cmur_tex.append(caste_tex[i])
            cmur_date.append(caste_date[i])
        else:
            nnother.append(caste[i])
            nnother_tex.append(caste[i])
            nnother_loc.append(caste[i])
            nnother_date.append(caste[i])

nnn = []
nnn_loc = []
nnn_tex = []
nnn_date = []
m = ["kidnap", "abduct", "missing"]
for i in range(len(nnother)):
    for j in m:
        if j in nnother[i]:
            c_kid.append(nnother[i])
            ckid_loc.append(nnother_loc[i])
            ckid_tex.append(nnother_tex[i])
            ckid_date.append(nnother_date[i])
        else:
            nnn.append(nnother[i])
            nnn_loc.append(nnother_loc[i])
            nnn_tex.append(nnother_tex[i])
            nnn_date.append(nnother_date[i])

nnnn = []
nnnn_loc = []
nnnn_tex = []
nnnn_date = []
m = ["rape", "gang-rape", "sexually harrass", "harrass"]
for i in range(len(nnn)):
    for j in m:
        if j in nnn[i]:
            c_rap.append(nnn[i])
            crap_loc.append(nnn_loc[i])
            crap_tex.append(nnn_tex[i])
            crap_date.append(nnn_date[i])
        else:
            nnnn.append(nnn[i])
            nnnn_loc.append(nnn_loc[i])
            nnnn_tex.append(nnn_tex[i])
            nnnn_date.append(nnn_date[i])

s = []
s_loc = []
s_tex = []
s_date = []
m = ["honor", "honor killing", "honor-killing", "honour", "honour killing", "honour-killing", "honour kill",
     "honour-kill"]
for i in range(len(nnnn)):
    for j in m:
        if j in nnnn[i]:
            c_hon.append(nnnn[i])
            chon_loc.append(nnnn_loc[i])
            chon_tex.append(nnnn_tex[i])
            chon_date.append(nnnn_date[i])
        else:
            s.append(nnnn[i])
            s_loc.append(nnnn_loc[i])
            s_tex.append(nnnn_tex[i])
            s_date.append(nnnn_date[i])
            

ss = []
ss_loc = []
ss_tex = []
ss_date = []
m = ["assault", "abuse", "attack", "beat up", "beaten", "thrash", "thrown", "threw", "pelt", "stone", "hit", "punch",
     "forced to ", "choke"]
for i in range(len(s)):
    for j in m:
        if j in s[i]:
            c_ass.append(s[i])
            cass_loc.append(s_loc[i])
            cass_tex.append(s_tex[i])
            cass_date.append(s_date[i])
        else:
            ss.append(s[i])
            ss_loc.append(s_loc[i])
            ss_tex.append(s_tex[i])
            ss_date.append(s_date[i])

m = ["protest", "boycott", "march", "campaign", "demand", "protestor"]
for i in range(len(ss)):
    for j in m:
        if j in ss[i]:
            c_pol.append(ss[i])
            cpol_loc.append(ss_loc[i])
            cpol_tex.append(ss_tex[i])
            cpol_date.append(ss_date[i])
        else:
            c_oth.append(ss[i])
            coth_loc.append(ss_loc[i])
            coth_tex.append(ss_tex[i])
            coth_date.append(ss_date[i])

m = None
nother = None
nnother = None
nnn = None
nnnn = None
ss = None
s = None

# news_data5 = pd.read_csv("Water.csv", header=0)
# news_data6 = pd.read_csv("Land.csv", header=0)
# news_data7 = pd.read_csv("Religious.csv", header=0)
# news_data8 = pd.read_csv("Wedding.csv", header=0)
# news_data9 = pd.read_csv("Daily.csv", header=0)
label = []
news = news_data5 + news_data6 + news_data7 + news_data8 + news_data9

for i in range(len(news_data5)):
    label.append(0)
for i in range(len(news_data6)):
    label.append(1)
for i in range(len(news_data7)):
    label.append(2)
for i in range(len(news_data8)):
    label.append(3)
for i in range(len(news_data9)):
    label.append(4)
data = [news, label]

vectorizer = CountVectorizer()
text_data = vectorizer.fit_transform(news)

# Split the data into training and testing sets
print(text_data.shape)
label = np.transpose(label)
print(label.shape)
X_train, X_test, y_train, y_test = train_test_split(text_data, label, test_size=0.2, random_state=42, shuffle=True)
# Train the model
model = BernoulliNB()
model.fit(X_train, y_train)
# Predict on the testing data
y_pred = model.predict(X_test)
# Calculate the accuracy
accuracy = accuracy_score(y_test, y_pred)
print("Accuracy:", accuracy)
# Train the model
model = BernoulliNB()
model.fit(text_data, label)
# Save the model for later use
joblib.dump(model, "NB4label.pkl")
#
# Load the model (if already trained)
model = joblib.load("NB4label.pkl")
unlabel = dis_con
title = dis

# Prepare the new, unlabelled data
vectorizer = CountVectorizer()
vectorizer.fit(news)
new_text_data = vectorizer.transform(unlabel)

# Predict the labels for the new data
predicted_labels = model.predict(new_text_data)

path = "/Users/sallybun/Desktop"

for i in range(len(predicted_labels)):
    if predicted_labels[i] == 0:
        d_wat.append(dis[i])
        dwat_date.append(dis_date[i])
        dwat_loc.append(dis_loc[i])
        dwat_tex.append(dis_tex[i])

    if predicted_labels[i] == 1:
        d_lan.append(dis[i])
        dlan_date.append(dis_date[i])
        dlan_loc.append(dis_loc[i])
        dlan_tex.append(dis_tex[i])
        
    if predicted_labels[i] == 2:
        d_rel.append(dis[i])
        drel_date.append(dis_date[i])
        drel_loc.append(dis_loc[i])
        drel_tex.append(dis_tex[i])

    if predicted_labels[i] == 3:
        d_wed.append(dis[i])
        dwed_date.append(dis_date[i])
        dwed_loc.append(dis_loc[i])
        dwed_tex.append(dis_tex[i])

    else:
        d_dai.append(dis[i])
        ddai_date.append(dis_date[i])
        ddai_loc.append(dis_loc[i])
        ddai_tex.append(dis_tex[i])

label = None
news_data0 = None
news_data1 = None
news_data2 = None
news_data3 = None
news_data4 = None
news_data5 = None
news_data6 = None
news_data7 = None
news_data8 = None

caste = None
dis = None
other = None
caste_con = None
dis_con = None
other_con = None
caste_tex = None
caste_loc = None
caste_date = None
dis_tex = None
dis_loc = None
dis_date = None
other_tex = None
other_loc = None
other_date = None
        
c1 = []
c2 = c_hon + c_mur + c_kid + c_rap + c_ass + c_pol + c_oth + d_wat + d_lan + d_rel + d_wed + d_dai + o_hon + o_mur + o_kid + o_rap + o_ass + o_pol + o_oth
# c2 = c_hon + c_mur + c_kid + c_rap + c_ass + c_pol + c_oth
c3 = chon_tex + cmur_tex + ckid_tex + crap_tex + cass_tex + cpol_tex + coth_tex + dwat_tex + dlan_tex + drel_tex + dwed_tex + ddai_tex + ohon_tex + omur_tex + okid_tex + orap_tex + oass_tex + opol_tex + ooth_tex
# c3 = chon_tex + cmur_tex + ckid_tex + crap_tex + cass_tex + cpol_tex + coth_tex
c4 = chon_date + cmur_date + ckid_date + crap_date + cass_date + cpol_date + coth_date + dwat_date + dlan_date + drel_date + dwed_date + ddai_date + ohon_date + omur_date + okid_date + orap_date + oass_date + opol_date + ooth_date
# c4 = chon_date + cmur_date + ckid_date + crap_date + cass_date + cpol_date + coth_date
c5 = chon_loc + cmur_loc + ckid_loc + crap_loc + cass_loc + cpol_loc + coth_loc + dwat_loc + dlan_loc + drel_loc + dwed_loc + ddai_loc + ohon_loc + omur_loc + okid_loc + orap_loc + oass_loc + opol_loc + ooth_loc
# c5 = chon_loc + cmur_loc + ckid_loc + crap_loc + cass_loc + cpol_loc + coth_loc

for i in c_hon:
    c1.append("Caste Violence - Honour Killing")
for i in c_mur:
    c1.append("Caste Violence - Killing")
for i in c_kid:
    c1.append("Caste Violence - Kidnapping")
for i in c_rap:
    c1.append("Caste Violence - Rape/Harassment")
for i in c_ass:
    c1.append("Caste Violence - Assault/Abuse/Attack")
for i in c_pol:
    c1.append("Caste Violence - Political/Protest")
for i in c_oth:
    c1.append("Caste Violence - Other")
for i in d_wat:
    c1.append("Caste Discrimination - Water")
for i in d_lan:
    c1.append("Caste Discrimination - Land Dispute")
for i in d_rel:
    c1.append("Caste Discrimination - Religious")
for i in d_wed:
    c1.append("Caste Discrimination - Wedding")
for i in d_dai:
    c1.append("Caste Discrimination - Daily")

for i in o_hon:
    c1.append("Casual Violence - Honour Killing")
for i in o_mur:
    c1.append("Casual Violence - Killing")
for i in o_kid:
    c1.append("Casual Violence - Kidnapping")
for i in o_rap:
    c1.append("Casual Violence - Rape/Harassment")
for i in o_ass:
    c1.append("Casual Violence - Assault/Abuse/Attack")
for i in o_pol:
    c1.append("Casual Violence - Political/Protest")
for i in o_oth:
    c1.append("Casual Violence - Other")
    
c_mur = None
cmur_tex = None
cmur_loc = None
cmur_date = None
c_kid = None
ckid_tex = None
ckid_loc = None
ckid_date = None
c_rap = None
crap_tex = None
crap_loc = None
crap_date = None
c_hon = None
chon_tex = None
chon_loc = None
chon_date = None
c_pol = None
cpol_tex = None
cpol_loc = None
cpol_date = None
c_ass = None
cass_tex = None
cass_loc = None
cass_date = None
c_oth = None
coth_tex = None
coth_loc = None
coth_date = None

o_mur = None
omur_tex = None
omur_loc = None
omur_date = None
o_kid = None
okid_tex = None
okid_loc = None
okid_date = None
o_rap = None
orap_tex = None
orap_loc = None
orap_date = None
o_hon = None
ohon_tex = None
ohon_loc = None
ohon_date = None
o_pol = None
opol_tex = None
opol_loc = None
opol_date = None
o_ass = None
oass_tex = None
oass_loc = None
oass_date = None
o_oth = None
ooth_tex = None
ooth_loc = None
ooth_date = None

d_wat = None
dwat_tex = None
dwat_loc = None
dwat_date = None
d_lan = None
dlan_tex = None
dlan_loc = None
dlan_date = None
d_wed = None
dwed_tex = None
dwed_loc = None
dwed_date = None
d_rel = None
drel_tex = None
drel_loc = None
drel_date = None
d_dai = None
ddai_tex = None
ddai_loc = None
ddai_date = None

nother = None
nother_tex = None
nother_loc = None
nother_date = None


path = "/Users/sallybun/Desktop"
os.chdir(path)
import pandas as pd

df = pd.DataFrame.from_dict({"Violence Type": c1 ,"Title": c2, "Text Contents": c3, "Date": c4, "Location": c5}, orient='index')
df = df.transpose()

# Create a Pandas Excel writer using XlsxWriter as the engine.
writer = pd.ExcelWriter('Hindus2010-2013NewDoc.xlsx', engine='xlsxwriter')

# Convert the dataframe to an XlsxWriter Excel object.
df.to_excel(writer, sheet_name='Sheet1', index=False)

# Close the Pandas Excel writer and output the Excel file.
writer.close()






