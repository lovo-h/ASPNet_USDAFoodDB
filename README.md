# Creating the Docker Image: USDA Food Nutrition Database
This Docker image uses data provided by the United States Department of Agriculture, Agricultural Research Service (USDA ARS). According to the USDA ARS, this data is the major source of food composition data in the United States and provides the foundation for most food composition databases in the public and private sectors. They indicate that this data-set contains information on 7,793 food items and up to 150 food components.


##### Requirements
Here are the items that were used to create this database:
* The documentation file: `SR-Legacy_Doc.pdf`. Provided in a zip file in this repo.
* All the ASCII data-files. Listed below and provided in a zip file in this repo.
* The database structure. Displayed below.
* The database relationsihps. Listed below.

###### ASCII data-files
Required data-files, obtained from the USDA website:

| | | | |
| :---: | :---: | :---: | :---: |
| DATA_SRC.txt | DATSRCLN.txt | DERIV_CD.txt | FD_GROUP.txt |
| FOOD_DES.txt | FOOTNOTE.txt | LANGDESC.txt | LANGUAL.txt |
| NUT_DATA.txt | NUTR_DEF.txt | SRC_CD.txt | WEIGHT.txt |

**Note**: these files, along with the documentation, can be found in `USDAFoodDB/Src/SR-Leg_ASC.zip`

###### Database Structure
![alt text](./Src/Assets/usda_food_schema.png "Database Structure")

###### Database Relationships
| | | | | |
| ---: | --- | ---: | --- | --- |
| **ONE** | FOOD_DES (p) | **TO MANY** | NUT_DATA (d) | |
| **ONE** | FOOD_DES (p) | **TO MANY** | WEIGHT (d) | |
| **ONE** | FOOD_DES (p) | **TO MANY** | FOOTNOTE (d) | |
| **ONE** | FD_GROUP (p) | **TO MANY** | FOOD_DES (d) | |
| **MANY** | FOOD_DES (p) | **TO MANY** | LANGDESC (p) | intermediary: LANGUAL (d) |
| **ONE** | SRC_CD (p) | **TO MANY** | NUT_DATA (d) | |
| **ONE** | DERIV_CD (p) | **TO MANY** | NUT_DATA (d) | |
| **ONE** | NUTR_DEF (p) | **TO MANY** | NUT_DATA (d) | |
| **MANY** | NUT_DATA| **TO MANY** | DATA_SRC | intermediary: DATASRCLN |

**Note**: the principal entities are marked with (p) and the dependent entities are marked with (d)

